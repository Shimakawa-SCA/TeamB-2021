using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class Clear2 : MonoBehaviour
{
    [SerializeField] private GameObject GameClearImag;
    [SerializeField] private GameObject ClearPanel;
    [SerializeField] private GameObject aClearImag;
    [SerializeField] private GameObject bClearImag;
    [SerializeField] private Button NextButton;
    [SerializeField] private Button TitleButton;

    // Start is called before the first frame update
    void Start()
    {

        ClearPanel.SetActive(false);
        GameClearImag.SetActive(false);
        aClearImag.SetActive(false);
        bClearImag.SetActive(false);
        Pausable.NotMenuCount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //時間        
        if (TimeCounter2.countdown2 > 120)
        {
            aClearImag.SetActive(true);
        }

        if (TakesanPlayerScript2.R2Count < 4)
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
        //クリア音
        //NewSoundScriot.Clear1 = true;
        GameClearImag.SetActive(true);
        GameClearImag.SetActive(true);
        Invoke("CPanel", 1);
        TimeCounter2.tTime2 = 0;
        Debug.Log(TimeCounter.tTime);
        //DeleteTargetObj という名前のオブジェクトを取得
        GameObject obj = GameObject.Find("New Sprite");
        // 指定したオブジェクトを削除
        Destroy(obj);
        Pausable.NotMenuCount = 1;
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
