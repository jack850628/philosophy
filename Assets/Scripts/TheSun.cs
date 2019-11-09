using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheSun : MonoBehaviour {

    [SerializeField] float vibrationMagnitude;
    [SerializeField] GameObject skill1Prefab;
    [SerializeField] GameObject skill2Prefab;
    [SerializeField] ParticleSystem fx1, fx2;

    
    void Update() {
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            if(Random.value < 0.2) {         
                Skill_1();   
            }
            else if(Random.value < 1.0) {
                Skill_2();   
            }
        }
        Vector3 move = new Vector3(Input.GetAxis("Mouse X"), 0,0);
        this.transform.position += move;
    }

    void Skill_1() {
        GameObject obj = Instantiate(skill1Prefab, this.transform.position, Quaternion.identity);
        Vector2 vibration = Random.insideUnitCircle * vibrationMagnitude;
        Rigidbody rigid = obj.GetComponent<Rigidbody>();
        rigid.velocity += new Vector3(vibration.x, vibration.y, 0) + Vector3.down;

        fx1.Play();
    }
    
    void Skill_2() {
        GameObject obj = Instantiate(skill2Prefab, this.transform.position, Quaternion.identity);
        Vector2 vibration = Random.insideUnitCircle * vibrationMagnitude;
        Rigidbody rigid = obj.GetComponent<Rigidbody>();
        rigid.velocity += new Vector3(vibration.x, vibration.y, 0) + Vector3.down;

        fx2.Play();
    }
}
