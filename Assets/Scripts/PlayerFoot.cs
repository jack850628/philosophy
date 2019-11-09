using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//玩家物件的腳
public class PlayerFoot : MonoBehaviour
{
    private Player player;
    private int standOnFootCount = 0;
    private void Start()
    {
        player = gameObject.transform.parent.GetComponent<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Foot"))
        {
            player.canJump = true;
            standOnFootCount++;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Foot"))
        {
            if(--standOnFootCount == 0)
                player.canJump = false;
        }
    }
}
