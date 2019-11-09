using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

//道具
public class Prop : MonoBehaviour
{
    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.DOShakePosition(0.5f, new Vector2(0.3f, 0.3f));
            Debug.Log("吃");
        }
    }
}
