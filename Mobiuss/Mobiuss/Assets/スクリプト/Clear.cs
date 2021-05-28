using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class Clear : MonoBehaviour
{
    [SerializeField] private GameObject GameClearImag;
    [SerializeField] private GameObject ClearPanel;
    [SerializeField] private GameObject aClearImag;
    [SerializeField] private GameObject bClearImag;

    GameObject countdown; //countdownそのものが入る変数
    TimeCounter timeCounter; //TimeCounterが入る変数

    [SerializeField] private Button NextButton;
    [SerializeField] private Button TitleButton;

    public static int NotMenuCount;


    // Start is called before the first frame update
    void Start()
    {

        ClearPanel.SetActive(false);
        GameClearImag.SetActive(false);
        aClearImag.SetActive(false);
        bClearImag.SetActive(false);
        countdown = GameObject.Find("Timer"); //countdownをオブジェクトの名前から取得して変数に格納する
        timeCounter = countdown.GetComponent<TimeCounter>(); //countdownの中にあるTimeCounterを取得して変数に格納する
        NotMenuCount = 0;

    }

    // Update is called once per frame
    void Update()
    {        
        //Debug.Log(NewPlayer4Script.R1Count);
        //時間
        float countdowntime = timeCounter.countdown; //新しく変数を宣言してその中にTimeCounterの変数countdownを代入する
        //Debug.Log("クリアまでの時間" + countdowntime);
        if (countdowntime > 120)
        {
            aClearImag.SetActive(true);
        }

        if (TakesanPlayerScript1.R1Count < 4)
        {
            bClearImag.SetActive(true);
        }
        else
        {
            bClearImag.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameClearImag.SetActive(true);
        Invoke("CPanel", 1);
        TimeCounter.tTime = 0;
        Debug.Log(TimeCounter.tTime);
        //DeleteTargetObj という名前のオブジェクトを取得
        GameObject obj = GameObject.Find("New Sprite");
        // 指定したオブジェクトを削除
        Destroy(obj);
        NotMenuCount = 1;
    }

    void CPanel()
    {
        ClearPanel.SetActive(true);
        GameClearImag.SetActive(false);
        // 最初に選択状態にしたいボタンの設定
        NextButton.Select();

    }

    
    // if (other.gameObject.CompareTag("player"))
    //    {
    //      SceneManager.LoadScene("stage2");
    //    }
}
