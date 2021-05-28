using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeCounter3 : MonoBehaviour
{
    //カウントダウン
    public static float countdown3 = 300.0f;

    //時間を表示するText型の変数
    public Text timeText;
    [SerializeField] private GameObject TimeOverPanel;
    [SerializeField] private Button TimeButton;
    bool isCalledOnce;

    public static int tTime3;

    void Start()
    {
        TimeOverPanel.SetActive(false);
        tTime3 = 0;
        isCalledOnce = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (tTime3 == 1)
        {
            //時間をカウントダウンする
            countdown3 -= Time.deltaTime;
            //時間を表示する
            timeText.text = countdown3.ToString("f1") + "秒";

            //countdownが0以下になったとき
            if (countdown3 <= 0)
            {
                timeText.text = "時間になりました！";
                TimeOverPanel.SetActive(true);
                if (!isCalledOnce)
                {
                    //タイムオーバー音
                    //NewSoundScriot.GameOver1 = true;
                    isCalledOnce = true;
                    TimeButton.Select();
                }

                //Invoke("GameOver", 1.0f);
                //SceneManager.LoadScene("GameOver");
            }
        }
        /*void GameOver()
        {
            SceneManager.LoadScene("GameOver");
        }*/
    }
    //やり直しボタン
    public void OnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //タイトルに行くボタン
    public void OnClickT()
    {
        SceneManager.LoadScene("Prologue");
    }

}