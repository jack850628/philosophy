using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruction : MonoBehaviour {

    float countDown = 10f;
    
    void Update() {
        countDown -= Time.deltaTime;
        if(countDown < 0)
            Destroy(this.gameObject);
    }
}
