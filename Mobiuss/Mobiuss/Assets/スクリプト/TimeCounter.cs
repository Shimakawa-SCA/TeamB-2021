using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeCounter : MonoBehaviour
{
    //カウントダウン
    public float countdown = 5.0f;

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
    }
    // Update is called once per frame
    void Update()
    {
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
                TimeOverPanel.SetActive(true);
                if (!isCalledOnce)
                {
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
        SceneManager.LoadScene("Opening");
    }

}