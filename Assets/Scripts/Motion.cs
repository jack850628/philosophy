using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour {

    public Vector3 speed = Vector3.down;
    public Vector3 angularSpeed = Vector3.zero;
    
    void Update() {
        this.transform.position += speed * Time.deltaTime;
        this.transform.Rotate( angularSpeed * Time.deltaTime );
    }
}
