using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Settlement : MonoBehaviour
{
    //物件動態
    [SerializeField] Transform[] MoveObjs;
    [SerializeField] Vector3[] target_pos;
    [SerializeField] float[] duration;
    [SerializeField] Ease _moveEase = Ease.Linear;
    //背景
    [SerializeField] Transform[] BackGround;
    [SerializeField]Vector3 mini, max;
    [SerializeField]float speed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Start_Settlement());
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < BackGround.Length; i++)
        {
            BackGround[i].position = new Vector3(BackGround[i].position.x-speed, BackGround[i].position.y, BackGround[i].position.z);
            if (BackGround[i].position.x < mini.x)
            {
                BackGround[i].position = max;
            }
            
        }
        
    }
    IEnumerator Start_Settlement()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < target_pos.Length; i++)
        {
            MoveObjs[i].DOMove(target_pos[i], duration[i]);
        }
    }
}
