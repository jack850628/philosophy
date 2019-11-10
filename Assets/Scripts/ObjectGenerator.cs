using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour {

    [SerializeField] GameObject[] prefabs = new GameObject[0];

    public float EstObjPerSecond = 1;
    System.Random rnd = new System.Random();

    [SerializeField] Bounds bounds;
    

    private void Update() {
        if (GameStatus.gameStatus != GameStatus.Status.RUNNING) return;

        int k = SamplePoisson(EstObjPerSecond * Time.deltaTime);
        for(int i = 0; i < k; i++) {
            if(prefabs.Length > 0)
                GenerateNextObject();
        }

        {
            Debug.DrawLine(new Vector3(bounds.min.x, bounds.min.y, bounds.min.z),
                            new Vector3(bounds.min.x, bounds.min.y, bounds.max.z),
                            Color.red);
            Debug.DrawLine(new Vector3(bounds.min.x, bounds.max.y, bounds.min.z),
                            new Vector3(bounds.min.x, bounds.max.y, bounds.max.z),
                            Color.red);
            Debug.DrawLine(new Vector3(bounds.max.x, bounds.min.y, bounds.min.z),
                            new Vector3(bounds.max.x, bounds.min.y, bounds.max.z),
                            Color.red);
            Debug.DrawLine(new Vector3(bounds.max.x, bounds.max.y, bounds.min.z),
                            new Vector3(bounds.max.x, bounds.max.y, bounds.max.z),
                            Color.red);

            Debug.DrawLine(new Vector3(bounds.min.x, bounds.min.y, bounds.min.z),
                            new Vector3(bounds.min.x, bounds.max.y, bounds.min.z),
                            Color.red);
            Debug.DrawLine(new Vector3(bounds.min.x, bounds.min.y, bounds.max.z),
                            new Vector3(bounds.min.x, bounds.max.y, bounds.max.z),
                            Color.red);
            Debug.DrawLine(new Vector3(bounds.max.x, bounds.min.y, bounds.min.z),
                            new Vector3(bounds.max.x, bounds.max.y, bounds.min.z),
                            Color.red);
            Debug.DrawLine(new Vector3(bounds.max.x, bounds.min.y, bounds.max.z),
                            new Vector3(bounds.max.x, bounds.max.y, bounds.max.z),
                            Color.red);

            Debug.DrawLine(new Vector3(bounds.min.x, bounds.min.y, bounds.min.z),
                            new Vector3(bounds.max.x, bounds.min.y, bounds.min.z),
                            Color.red);
            Debug.DrawLine(new Vector3(bounds.min.x, bounds.min.y, bounds.max.z),
                            new Vector3(bounds.max.x, bounds.min.y, bounds.max.z),
                            Color.red);
            Debug.DrawLine(new Vector3(bounds.min.x, bounds.max.y, bounds.min.z),
                            new Vector3(bounds.max.x, bounds.max.y, bounds.min.z),
                            Color.red);
            Debug.DrawLine(new Vector3(bounds.min.x, bounds.max.y, bounds.max.z),
                            new Vector3(bounds.max.x, bounds.max.y, bounds.max.z),
                            Color.red);
        }
    }

    private void GenerateNextObject() {
        int i = rnd.Next() % prefabs.Length;
        Vector3 pos_uniform = new Vector3(Random.value, Random.value, Random.value);
        Vector3 pos = bounds.min + Vector3.Scale(pos_uniform, bounds.max - bounds.min);
        Instantiate(prefabs[i], pos, Quaternion.identity);
    }

    public static int SamplePoisson(float lambda) {
        float L = Mathf.Exp(-lambda);
        int k = 0;
        float p = 1;
        do {
            k = k + 1;
            p = Random.value * p;
        } while(p > L);
        return k - 1;
    }
}
