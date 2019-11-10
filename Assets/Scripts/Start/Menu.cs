using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    [SerializeField] GameObject LOGO_C,Shady_C;//抓取LOGO跟Shady的Canvas群組
    [SerializeField] CanvasGroup Shady,Button;
    [SerializeField]RectTransform Title;
    [SerializeField] string Next_Scene;
    bool LOGO_fade,title_jump,Button_fade,Mus_fade;

    AudioSource AS;
    [SerializeField] AudioClip LobbyMus;
    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
        DOTween.defaultEaseType = Ease.InBounce;
        StartCoroutine(LOGO_Show());
    }

    // Update is called once per frame
    void Update()
    {
        if (LOGO_fade == false&&Shady.alpha<1)
        {
            Shady.alpha += Time.deltaTime;
        }
        else if(LOGO_fade == true&& Shady.alpha >0)
        {
            Shady.alpha -= Time.deltaTime;
        }
        //Title跳動
        if (title_jump == true)
        {
            StartCoroutine(Title_Show());
        }
        //按鈕閃爍
        if (Button_fade == true && Button.alpha < 1)
        {
            Button.alpha += Time.deltaTime;
        }
        else if (Button_fade == false && Button.alpha > 0)
        {
            Button.alpha -= Time.deltaTime;
        }
        else if (Button.alpha >= 1 | Button.alpha <= 0)
        {
            Button_fade = !Button_fade;
        }

        if (Mus_fade == true&&AS.volume<1)
        {
            AS.volume += Time.deltaTime * 0.5f;
        }else if(Mus_fade == false && AS.volume > 0)
        {
            AS.volume -= Time.deltaTime ;
        }
    }
    //LOGO淡入淡出
    IEnumerator LOGO_Show()
    {
        yield return new WaitForSeconds(1);
        LOGO_fade = true;
        yield return new WaitForSeconds(3);
        LOGO_fade = false;
        yield return new WaitForSeconds(1.5f);
        LOGO_C.SetActive(false);
        LOGO_fade = true;
        title_jump = true;
        AS.PlayOneShot(LobbyMus);
        Mus_fade = true;
        yield return new WaitForSeconds(1f);
        Shady_C.SetActive(false);
    }
    IEnumerator Title_Show()
    {
        title_jump = false;
        yield return new WaitForSeconds(1.5f);
        Title.DOScale(1.2f, 0.2f);
        yield return new WaitForSeconds(0.1f);
        Title.DOScale(1f, 0.1f);

        yield return new WaitForSeconds(1f);
        Title.DOScale(1.2f, 0.1f);
        yield return new WaitForSeconds(0.1f);
        Title.DOScale(1f, 0.1f);

        yield return new WaitForSeconds(0.1f);
        Title.DOScale(1.2f, 0.1f);
        yield return new WaitForSeconds(0.1f);
        Title.DOScale(1f, 0.1f);
        title_jump = true;
    }

    public void TriggerBottom()
    {
        StartCoroutine(Bottom());
    }
     IEnumerator Bottom()
    {
        Mus_fade = false;
        Shady_C.SetActive(true);
        LOGO_fade = false;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(Next_Scene);
    }
}
