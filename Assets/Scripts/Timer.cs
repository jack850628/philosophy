using System;
using UnityEngine;
using UnityEngine.UI;

//計時器
public class Timer : MonoBehaviour
{
    private Action callBack;
    private int sec;
    private Text time;
    private AudioSource audioSource;


    public AudioClip timeteSsion,timeUp;

    public void startTime(int sec, Action callBack)
    {
        this.sec = sec;
        this.callBack = callBack;
        time = GetComponent<Text>();
        InvokeRepeating("tamer", 1f, 1f);
        audioSource = GetComponent<AudioSource>();
    }
    void tamer()
    {
        time.text = sec.ToString("0");
        if (--sec < 0)
        {
            callBack();
            CancelInvoke("tamer");
        }
        if(sec <= 10)
        {
            audioSource.PlayOneShot(timeteSsion);
        }
        else if (sec == 0)
        {
            audioSource.PlayOneShot(timeUp);
        }
    }
}
