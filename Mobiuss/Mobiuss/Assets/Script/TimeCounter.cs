using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeCounter : MonoBehaviour
{
    //カウントダウン
    public float countdown = 300.0f;
    //取得用関数
    public float Getcountdown()
    {
        return countdown;
    }

    //時間を表示するText型の変数
    public Text timeText;

    public TextDisplay TextDisplay;
    int tTime;
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        tTime = TextDisplay.TextTime;
        if (tTime == 1)
        {
            //時間をカウントダウンする
            countdown -= Time.deltaTime;
            //時間を表示する
            timeText.text = countdown.ToString("f1") + "秒";

            //countdownが0以下になったとき
            if (countdown <= 0)
            {
                timeText.text = "時間になりました！";
                //Invoke("GameOver", 1.0f);
                SceneManager.LoadScene("GameOver");
            }
        }
        void GameOver()
        {
            SceneManager.LoadScene("GameOver");
        }


    }
}