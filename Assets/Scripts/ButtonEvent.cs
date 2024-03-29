<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ButtonEvent : MonoBehaviour
{
    [SerializeField] GameObject Select,Kid_Canvas;//選腳色的群組
    AudioSource AS;
    [SerializeField] AudioClip GameStart,Warning;//開始音效
    [SerializeField] CanvasGroup CG;
    bool ST,HiddenSkill;
    [SerializeField] Image[] ready;
    [SerializeField] Image Start_Button,Kid;

    [SerializeField] float duration;
    [SerializeField] Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        AS = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //控制黑幕
        if (ST == true && CG.alpha < 1)
        {
            CG.alpha += Time.deltaTime * 1;
        }
        else if ((ST == false && CG.alpha > 0))
        {
            CG.alpha -= Time.deltaTime * 1;
        }
        if (CG.alpha >= 1)
        {
            Select.SetActive(false);
            ST = false;
        }
        else if (CG.alpha <= 0)
        {
            CG.gameObject.SetActive(false);
        }
        //按鍵變明暗
        if (ready[0].enabled == true && ready[1].enabled == true && ready[2].enabled == true && ready[3].enabled == true)
        {
            Start_Button.color = new Color32(255, 255, 255, 255);
        }
        else
        {
            Start_Button.color = new Color32(100, 100, 100, 255);
        }
    }
    //按鍵按下
    public void StartLearning()
    {
        if (ready[0].enabled == true && ready[1].enabled == true && ready[2].enabled == true && ready[3].enabled == true)
        {
            AS.PlayOneShot(GameStart);
            CG.gameObject.SetActive(true);
            ST = true;
            if (HiddenSkill == true|Input.GetKey(KeyCode.B))
            {
                StartCoroutine(warn());
                Kid_Canvas.SetActive(true);
                Kid.transform.DOMove(pos,duration);
           }
        }
    }
    IEnumerator warn()
    {
        
        AS.clip = Warning;
        AS.Play();
        AS.loop = true;
        yield return new WaitForSeconds(2f);
        AS.loop = false;
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
    [SerializeField] GameObject Select;//選腳色的群組
    AudioSource AS;
    [SerializeField] AudioClip GameStart;//開始音效
    [SerializeField] AudioClip GamePlaying;//開始遊玩背景音樂
    [SerializeField] CanvasGroup CG;
    bool ST;
    [SerializeField] Image[] ready;
    [SerializeField] Image Start_Button;
    // Start is called before the first frame update
    void Start()
    {
        AS = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //控制黑幕
        if (ST == true && CG.alpha < 1)
        {
            CG.alpha += Time.deltaTime * 1;
        }
        else if ((ST == false && CG.alpha > 0))
        {
            CG.alpha -= Time.deltaTime * 1;
        }
        if (CG.alpha >= 1)
        {
            Select.SetActive(false);
            ST = false;
        }
        else if (CG.alpha <= 0)
        {
            CG.gameObject.SetActive(false);
        }
        //按鍵變明暗
        if (ready[0].enabled == true && ready[1].enabled == true && ready[2].enabled == true && ready[3].enabled == true)
        {
            Start_Button.color = new Color32(255, 255, 255, 255);
        }
        else
        {
            Start_Button.color = new Color32(100, 100, 100, 255);
        }
    }
    //按鍵按下
    public void StartLearning()
    {
        if (ready[0].enabled == true && ready[1].enabled == true && ready[2].enabled == true && ready[3].enabled == true)
        {
            AS.PlayOneShot(GameStart);
            CG.gameObject.SetActive(true);
            ST = true;
            StartCoroutine(toGamePlay());
            GameStatus.gameStatus = GameStatus.Status.RUNNING;
            GameObject.Find("time").GetComponent<Timer>().startTime(60, () => {
                GameStatus.gameStatus = GameStatus.Status.STOP;
            });
        }
    }

    private IEnumerator toGamePlay()
    {
        yield return new WaitForSeconds(1.5f);
        AS.PlayOneShot(GamePlaying);
    }
}
>>>>>>> e4b6f9671a5db0a5021317d3ef30a7d4676bb7e0
