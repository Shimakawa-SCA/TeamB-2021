using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ImageEx : MonoBehaviour
{
    [SerializeField] private GameObject BookImag;
    [SerializeField] private GameObject BooksImag;
    [SerializeField] private Button StartButton;


    // Start is called before the first frame update
    void Start()
    {
        BookImag.SetActive(true);
        BooksImag.SetActive(false);
        
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            WhiteOut();
            
        }
        
    }



    void WhiteOut()
    {
        //FindObjectOfType<FadeController2>().StartFadeOut();
        FadeController2.isFadeOut = true;
        Invoke("Books",1.0f);
        Invoke("Whitein", 2.0f);
    }
    void Books()
    {
        BookImag.SetActive(false);
        BooksImag.SetActive(true);
    }
    void Whitein()
    {
        FadeController2.isFadeIn = true;
        TextFead.isFadeIn = true;
        //Invoke(StartButtin,2.0f);
        //FindObjectOfType<TextFead>().FadeIn();
    }
    /*void StartButtin()
    {
        StartButton.SetActive(true);
    }*/
}
