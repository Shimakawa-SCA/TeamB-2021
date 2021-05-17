using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Clear : MonoBehaviour
{
    [SerializeField] private GameObject GameClearImag;
    [SerializeField] private GameObject ClearPanel;
    [SerializeField] private GameObject aClearImag;
    [SerializeField] private GameObject bClearImag;

    GameObject countdown; //countdownそのものが入る変数
    TimeCounter timeCounter; //TimeCounterが入る変数
    GameObject i; //iそのものが入る変数
    GameDirectorScript script; //GameDirectorScriptが入る変数

    // Start is called before the first frame update
    void Start()
    {
        ClearPanel.SetActive(false);
        GameClearImag.SetActive(false);
        aClearImag.SetActive(false);
        bClearImag.SetActive(false);
        countdown = GameObject.Find("Timer"); //countdownをオブジェクトの名前から取得して変数に格納する
        timeCounter = countdown.GetComponent<TimeCounter>(); //countdownの中にあるTimeCounterを取得して変数に格納する
        i = GameObject.Find("GameDrector"); //iをオブジェクトの名前から取得して変数に格納する
        script = i.GetComponent<GameDirectorScript>(); //iの中にあるGameDirectorScriptを取得して変数に格納する

    }

    // Update is called once per frame
    void Update()
    {
        //時間
        float countdowntime = timeCounter.countdown; //新しく変数を宣言してその中にTimeCounterの変数countdownを代入する
        //Debug.Log("クリアまでの時間" + countdowntime);
        if (countdowntime > 120)
        {
            aClearImag.SetActive(true);
        }
        int icount = script.i; //新しく変数を宣言してその中にGameDirectorScriptの変数iを代入する
        //Debug.Log("復活回数は" + icount);
        if (icount < 5)
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
    }

    void CPanel()
    {
        ClearPanel.SetActive(true);
        GameClearImag.SetActive(false);
    }

    // if (other.gameObject.CompareTag("player"))
    //    {
    //      SceneManager.LoadScene("stage2");
    //    }
}
