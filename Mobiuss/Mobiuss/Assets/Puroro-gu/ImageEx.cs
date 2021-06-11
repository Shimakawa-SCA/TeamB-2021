using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ImageEx : MonoBehaviour
{
    [SerializeField] private GameObject BookImag;
    [SerializeField] private GameObject BooksImag;
    [SerializeField] private GameObject bottonPanel;
    int count;
    public static int NextSceneCount;
    // Start is called before the first frame update
    void Start()
    {
        BookImag.SetActive(true);
        BooksImag.SetActive(false);
        bottonPanel.SetActive(false);
        count = 0;
        NextSceneCount = 0;
    }



    // Update is called once per frame
    void Update()
    {
        if (count == 0 && Input.GetKeyDown(KeyCode.Space) || count == 0 && Input.GetKeyDown("joystick button 0"))
        {
            //ボタン音
            NewSoundScriot.TitleButton1 = true;
            WhiteOut();
            count++;
        }
    }



    void WhiteOut()
    {
        //FindObjectOfType<FadeController2>().StartFadeOut();
        FadeController2.isFadeOut = true;
        Invoke("Books",2.0f);

    }
    void Books()
    {
        BookImag.SetActive(false);
        BooksImag.SetActive(true);
        Invoke("Whitein", 1.0f);
    }
    void Whitein()
    {
        FadeController2.isFadeIn = true;
        ReviveImage.fadeIn = true;
        Invoke("StartButt",3.5f);
        //FindObjectOfType<TextFead>().FadeIn();
    }
    void StartButt()
    {
        bottonPanel.SetActive(true);
        //StoryFade.isFadeOut = true;
        NextSceneCount++;
    }
}
