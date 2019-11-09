using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HereComesTheSun : MonoBehaviour {

    KeyCode[] cheatCode = {
        KeyCode.UpArrow, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.DownArrow,
        KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.LeftArrow, KeyCode.RightArrow,
        KeyCode.B, KeyCode.A
    };

    int last_match = -1;

    [SerializeField] GameObject sunPrefab;
    [SerializeField] Vector3 pos;
    
    void Update() {
        if(Input.GetKeyDown(cheatCode[last_match + 1])) {
            last_match++;
            if(last_match == cheatCode.Length-1) {
                NewSun();
                last_match = -1;
            }
            Debug.Log(last_match);
        }
        else if(Input.anyKeyDown) {
            last_match = -1;
        }
    }

    void NewSun() {
        Debug.Log("New Sun");
        GameObject obj = Instantiate(sunPrefab);
        obj.transform.position = pos;
    }
}
