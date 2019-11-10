using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FloatingAround : MonoBehaviour {

    public float waitingTime = 10;
    public float stayingTime = 20;
    public Vector3 waitingPosition;
    public Vector3 enteringPosition;
    public float minSpeed = 2f;
    public float maxSpeed = 5f;
    public float minX, maxX;
    public float minY, maxY;
    
    Rigidbody rigid;
    float t;
    Vector3 target;

    enum State {
        Waiting,
        Entering,
        Staying,
        Leaving
    };

    State state;

    void Start() {
        rigid = this.GetComponent<Rigidbody>();
        this.transform.position = waitingPosition;
        t = 0;
        state = State.Waiting;
        target = waitingPosition;
    }

    void Update() {
        if (GameStatus.gameStatus != GameStatus.Status.RUNNING) return;

        t += Time.deltaTime;

        switch(state) {
        case State.Waiting:
            if(t > waitingTime) {
                state = State.Entering;
                t = 0;
                target = enteringPosition;
            }
            break;
        case State.Entering:
            if((transform.position - target).magnitude < 0.2) {
                state = State.Staying;
                t = 0;
            }
            break;
        case State.Staying:
            if(t > stayingTime) {
                state = State.Leaving;
                t = 0;
            }
            Vector3 pos = rigid.transform.position;
            pos.z = 0;
            rigid.transform.position = pos;
            if((transform.position - target).magnitude < 0.2) {
                target = new Vector3( minX + Random.value * (maxX - minX),
                                      minY + Random.value * (maxY - minY),
                                      0 );
            }
            break;
        case State.Leaving:
            target = waitingPosition;
            break;
        }
        
        Vector3 dir = target - this.transform.position;
        Vector3 vel = Vector3.Lerp(rigid.velocity, dir, 0.25f);
        if(vel.magnitude < minSpeed) {
            vel = vel.normalized * minSpeed;
        }
        else if(vel.magnitude > maxSpeed) {
            vel = vel.normalized * maxSpeed;
        }
        rigid.velocity = vel;
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Player") {
            Destroy(this.gameObject);
        }
    }
}
