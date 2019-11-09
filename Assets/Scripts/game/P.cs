using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P : Prop
{
    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("poi");
        }
    }
}
