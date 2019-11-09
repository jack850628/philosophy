using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class End : MonoBehaviour
{
    [SerializeField] GameObject[] img;
    [SerializeField] Vector3[] pos;
    [SerializeField] float duration; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator end()
    {
        for (int k = 0; k < img.Length; k++)
        {
            yield return new WaitForSeconds(duration);
            for (int i = 0; i < img.Length; i++)
            {

                img[i].transform.DOMove(pos[i], duration);
            }

        }

    }
}
