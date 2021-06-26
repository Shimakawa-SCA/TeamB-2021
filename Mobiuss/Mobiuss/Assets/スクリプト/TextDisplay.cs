using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextDisplay : MonoBehaviour
{
    //作やすひろ
    [SerializeField] private GameObject GameStartImage;
    [SerializeField] private GameObject StartText;
    [SerializeField] private GameObject secondText; 
    // Start is called before the first frame update
    void Start()
    {
        //DelayMethodを3.5秒後に呼び出す
        Invoke("DelayMethod", 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DelayMethod()
    {
        GameStartImage.SetActive(false);
        StartText.gameObject.SetActive(true);
        Invoke("DelayMethods", 2.5f); 
    }
    void DelayMethods()
    {
        StartText.gameObject.SetActive(false);
        secondText.gameObject.SetActive(true);
        Invoke("DelayMethodss", 2.5f);
    }
    void DelayMethodss()
    {
        secondText.gameObject.SetActive(false);
        //タイマーを進める
        TimeCounter.tTime = 1;
        TimeCounter2.tTime2 = 1;
        TimeCounter3.tTime3= 1;
        Pass.PlayerCanMove = true;
    }
}
