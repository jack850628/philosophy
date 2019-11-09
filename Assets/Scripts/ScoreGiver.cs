using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGiver : MonoBehaviour {

    public int score = 1;
    public bool once = true;
    
    private void OnCollisionEnter(Collision collision) {
        GameObject obj = collision.gameObject;
        if(obj.tag == "Player") {
            Debug.Log("Hi player!");
            Player player = obj.GetComponent<Player>();
            player.score += score;
            
            if(once) {
                Destroy(this.gameObject);
            }
        }
    }
}
