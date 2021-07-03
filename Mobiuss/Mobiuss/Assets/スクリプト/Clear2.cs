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
    [SerializeField] private GameObject MissionPanel;
    [SerializeField] private GameObject ButtonPanel;
    [SerializeField] private GameObject aClearImag;
    [SerializeField] private GameObject bClearImag;
    [SerializeField] private Button NextButton;
    [SerializeField] private Button TitleButton;

    // Start is called before the first frame update
    void Start()
    {

        ClearPanel.SetActive(false);
        MissionPanel.SetActive(false);
        ButtonPanel.SetActive(false);
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

        if (Pass.RespawnPoint < 6)
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
        NewSoundScriot.Clear1 = true;
        GameClearImag.SetActive(true);
        Invoke("FadeIn", 0.1f);
        Invoke("CPanel", 2.0f);
        TimeCounter2.tTime2 = 0;
        Debug.Log(TimeCounter.tTime);
        //DeleteTargetObj という名前のオブジェクトを取得
        //GameObject obj = GameObject.Find("New Sprite");
        // 指定したオブジェクトを削除
        Destroy(other.gameObject);
        Pausable.NotMenuCount = 1;
    }
    void FadeIn()
    {
        ClearImageFade.fadeIn = true;
    }
    void CPanel()
    {
        ClearPanel.SetActive(true);
        GameClearImag.SetActive(false);
        Invoke("MPanel", 1.5f);
    }
    void MPanel()
    {
        MissionPanel.SetActive(true);
        Invoke("BPanel", 1.5f);
    }
    void BPanel()
    {
        ButtonPanel.SetActive(true);
        // 最初に選択状態にしたいボタンの設定
        NextButton.Select();
    }
}
