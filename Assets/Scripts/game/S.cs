using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameStatus.gameStatus = GameStatus.Status.RUNNING;
        GameObject.Find("time").GetComponent<Timer>().startTime(60, () => {
            GameStatus.gameStatus = GameStatus.Status.STOP;
        });
    }
}
