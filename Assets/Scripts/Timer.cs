using System;
using UnityEngine;
using UnityEngine.UI;

//計時器
public class Timer : MonoBehaviour
{
    private Action callBack;
    private float sec;
    private bool isRun;
    private Text time;

    public void startTime(float sec, Action callBack)
    {
        this.sec = sec;
        this.callBack = callBack;
        isRun = true;
        time = GetComponent<Text>();
    }
    void Update()
    {
        if (isRun)
        {
            time.text = sec.ToString("0");
            if ((sec -= Time.deltaTime) <= 0)
            {
                isRun = false;
                callBack();
            }
        }
    }
}
