using System.Collections;
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
        Invoke("NextScene1",2.0f);
        FadeController2.isFadeOut = true;
        //ボタンを押す音
        NewSoundScriot.MenuButton1 = true;
    }
    void NextScene1()
    {
        SceneManager.LoadScene("Stage2");
    }
    public void Retry()
    {
        Invoke("Retry1",2.0f);
        FadeController2.isFadeOut = true;
        //ボタンを押す音
        NewSoundScriot.MenuButton1 = true;
    }
    void Retry1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnClickT()
    {
        Invoke("Title",2.0f);
        FadeController2.isFadeOut = true;
        //ボタンを押す音
        NewSoundScriot.MenuButton1 = true;
    }
    void Title()
    {
        SceneManager.LoadScene("Prologue");
    }
    public void Stage3()
    {
        Invoke("NextScene2", 2.0f);
        FadeController2.isFadeOut = true;
        //ボタンを押す音
        NewSoundScriot.MenuButton1 = true;
    }
    void NextScene2()
    {
        SceneManager.LoadScene("stage3");
    }
    public void Stage4()
    {
        Invoke("NextScene3", 2.0f);
        FadeController2.isFadeOut = true;
        //ボタンを押す音
        NewSoundScriot.MenuButton1 = true;
    }
    void NextScene3()
    {
        SceneManager.LoadScene("end");
    }
}
