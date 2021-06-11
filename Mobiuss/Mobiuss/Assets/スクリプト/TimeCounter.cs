using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeCounter : MonoBehaviour
{
    //カウントダウン
    public static float countdown = 300.0f;
    //時間を表示するText型の変数
    public Text timeText;
    [SerializeField] private GameObject TimeOverPanel;
    [SerializeField] private Button TimeButton;
    bool isCalledOnce;

    public static int tTime;

    void Start()
    {
        TimeOverPanel.SetActive(false);
        tTime = 0;
        isCalledOnce = false;
        countdown = 300.0f;
    }
    // Update is called once per frame
    void Update()
    {
        if (tTime == 1)
        {
            //時間をカウントダウンする
            countdown -= Time.deltaTime;
            //時間を表示する
            timeText.text = "残り" + ((int)countdown);

            //countdownが0以下になったとき
            if (countdown <= 0)
            {
                timeText.text = "時間になりました！";
                TimeOverPanel.SetActive(true);
                if (!isCalledOnce)
                {
                    //タイムオーバー音
                    NewSoundScriot.GameOver1 = true;
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