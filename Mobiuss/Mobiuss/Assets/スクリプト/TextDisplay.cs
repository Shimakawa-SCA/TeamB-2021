using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextDisplay : MonoBehaviour
{
    //作やすひろ
    [SerializeField] private GameObject GameStartImag;
    [SerializeField] private GameObject StartPanel;
    [SerializeField] private GameObject MessagePanel;
    public int TextTime = 0;
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
        GameStartImag.SetActive(false);
        StartPanel.SetActive(true);
        Invoke("DelayMethods", 3.0f);
    }
    void DelayMethods()
    {
        StartPanel.SetActive(false);
        MessagePanel.SetActive(true);
        Invoke("DelayMethodss", 3.0f); 
    }
    void DelayMethodss()
    {
        MessagePanel.SetActive(false);
        TextTime = 1;
    }
}
