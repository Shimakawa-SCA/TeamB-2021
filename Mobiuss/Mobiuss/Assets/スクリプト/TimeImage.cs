using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeImage : MonoBehaviour
{
    GameObject TimeOverimage; // 自分のオブジェクト取得用変数
    public float fadeStart = 1f; // フェード開始時間
    public static bool fadeIn = true; // trueの場合はフェードイン
    public float fadeSpeed = 1f; // フェード速度指定


    // Start is called before the first frame update
    void Start()
    {
        TimeOverimage = this.gameObject; // 自分のオブジェクト取得
        fadeIn = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (fadeIn)
        {
            fadeInFunc();
        }

    }

    void fadeInFunc()
    {
        if (TimeOverimage.GetComponent<Image>().color.a < 255)
        {
            UnityEngine.Color tmp = TimeOverimage.GetComponent<Image>().color;
            tmp.a = tmp.a + (Time.deltaTime * fadeSpeed);
            TimeOverimage.GetComponent<Image>().color = tmp;
        }
    }
}
