using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeOnDestroy : MonoBehaviour {
    public GameObject prefab;
    
    private void OnDestroy() {
        GameObject obj = Instantiate(prefab);
        obj.transform.position = this.transform.position;
        obj.transform.rotation = this.transform.rotation;
    }
}
