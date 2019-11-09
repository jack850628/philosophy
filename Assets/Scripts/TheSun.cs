using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class TheSun : MonoBehaviour {

    [SerializeField] float vibrationMagnitude;
    [SerializeField] GameObject eruptionPrefab;
    ParticleSystem fx;

    void Start() {
        fx = this.GetComponent<ParticleSystem>();
    }
    
    void Update() {
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            Debug.Log("click");
            Erruption();
        }
        Vector3 move = new Vector3(Input.GetAxis("Mouse X"), 0,0);
        this.transform.position += move;
    }

    void Erruption() {
        GameObject obj = Instantiate(eruptionPrefab, this.transform.position, Quaternion.identity);
        Vector2 vibration = Random.insideUnitCircle * vibrationMagnitude;
        Rigidbody rigid = obj.GetComponent<Rigidbody>();
        rigid.velocity += new Vector3(vibration.x, vibration.y, 0) + Vector3.down;

        fx.Play();
    }
}
