using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    int cha_ID;
    //這裡放該Player的按鍵,圖片文字等路徑
    [SerializeField] KeyCode L, R, U;
    [SerializeField] Text ControlL, ControlR, ControlU;
    [SerializeField] Image ready_Img;
    [SerializeField] AudioClip Button1, Button2;
    AudioSource AS;
    //[SerializeField]Text Info, Name;
    // [SerializeField] Image Img;
    //這裡塞各角色資訊
    // [SerializeField] string[]Cha_name;
    // [SerializeField] string[]Cha_info;
    // [SerializeField] Sprite[]Cha_img;
    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
        ControlL.text = L.ToString();
        ControlR.text = R.ToString();
        ControlU.text = U.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        /*    if (Input.GetKeyDown(L))
            {
                if (cha_ID > 0)
                {
                    cha_ID -= 1;
                }
                else
                {
                    cha_ID = Cha_name.Length-1;
                }
                Name.text = Cha_name[cha_ID];
                Info.text= Cha_info[cha_ID];
                Img.sprite = Cha_img[cha_ID];
                Img.SetNativeSize();
            }
            if (Input.GetKeyDown(R))
            {
                if (cha_ID <Cha_name.Length-1)
                {
                    cha_ID += 1;
                }
                else
                {
                    cha_ID = 0;
                }
                Name.text = Cha_name[cha_ID];
                Info.text = Cha_info[cha_ID];
                Img.sprite = Cha_img[cha_ID];
                Img.SetNativeSize();
            }*/
        if (Input.GetKeyDown(L)|Input.GetKeyDown(R))
        {
            if (ready_Img.enabled == false)
            {
                ready_Img.enabled = !ready_Img.enabled;
                AS.PlayOneShot(Button1);
            }
            else if (ready_Img.enabled == true)
            {
                ready_Img.enabled = !ready_Img.enabled;
                AS.PlayOneShot(Button2);
            }
        }
    }
}
