﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NewNextSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        SceneManager.LoadScene("Stage2");
        //ボタンを押す音
        NewSoundScriot.MenuButton1 = true;
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //ボタンを押す音
        NewSoundScriot.MenuButton1 = true;
    }
    public void OnClickT()
    {
        SceneManager.LoadScene("Prologue");
        //ボタンを押す音
        NewSoundScriot.MenuButton1 = true;
    }
    public void Stage3()
    {
        SceneManager.LoadScene("stage3");
        //ボタンを押す音
        NewSoundScriot.MenuButton1 = true;
    }
    public void Stage4()
    {
        SceneManager.LoadScene("end");
        //ボタンを押す音
        NewSoundScriot.MenuButton1 = true;
    }
}
