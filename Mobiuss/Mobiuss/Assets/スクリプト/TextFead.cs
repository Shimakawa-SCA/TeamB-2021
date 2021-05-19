using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //パネルのイメージを操作するのに必要

public class TextFead : MonoBehaviour
{
    //テキストのフェードイン
    [SerializeField] private float degreeInTime = 3.0f;
    // private float currentTime = 0.0f;　//時間計測
    public float fadeSpeed = 0.02f;　//フェードインのスピード
    private Color textColor;　　//テキストのカラー変数
    public static bool isFadeIn = false;

    //UIテキストを格納
    public GameObject RivieSpin; //称号RivieSpin


    // Use this for initialization
    void Start()
    {
        //称号のカラーを取得してアルファを０に初期化
        textColor = this.RivieSpin.GetComponent<Text>().color;
        textColor.a = 0;
        this.RivieSpin.GetComponent<Text>().color = textColor;
    }

    // Update is called once per frame
    void Update()
    {

        this.RivieSpin.GetComponent<Text>().text = ("RivieSpin"); //称号をテキストへ表示　degreeNameは表示させる文字列

        if (isFadeIn)
        {
            FadeIn();
        }
        //degreeInTime秒経ったらFadeInを呼ぶ
        //Invoke("FadeIn", degreeInTime);

        //または以下のように呼ぶか
        //currentTime += Time.deltaTime;                                  
        // if (degreeInTime < currentTime)
        // {
        //     FadeIn();
        // }

    }

    void FadeIn()
    {
        if (textColor.a <= 1)
        {
            textColor.a += fadeSpeed;　//アルファ値を徐々に＋する
            this.RivieSpin.GetComponent<Text>().color = textColor;　//テキストへ反映させる
        }
        else
        {
            isFadeIn = false;
        }
    }
}
