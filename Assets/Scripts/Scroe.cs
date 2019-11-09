    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scroe : MonoBehaviour
{
    public Text[] score;
    string[] old_score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        for(int i = 0; i < score.Length; i++)
        {
            if(old_score[i] != score[i].text)
            {
                old_score[i] = score[i].text;
            }
          
        }        
    }
}
