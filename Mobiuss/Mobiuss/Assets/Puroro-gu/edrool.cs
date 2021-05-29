
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class edrool : MonoBehaviour
{
    public GameObject white;

    int count = 0;

    [SerializeField] GameObject BText;

    [SerializeField] private float textScrollSpeed = 60;
    //　テキストの制限位置

    [SerializeField] private float limitPosition = 730f;
    //　エンドロールが終了したかどうか
    private bool isStopEndRoll;


    [SerializeField]
    float scale = 2.0f;

    bool isButtonPressed = false;

    //　シーン移動用コルーチン
    private Coroutine endRollCoroutine;


    private void Start()
    {
        count = 2;
        Debug.Log(count);
        Debug.Log("buttonB");
        Invoke("EndRoll",2.0f);
    }

    // Update is called once per frame
    void Update()
    {

        /*エンドロール開始
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
        {
            

        }*/
        //　エンドロール用テキストがリミットを越えるまで動かす
        if (transform.position.y <= limitPosition && count > 1)
        {
            BText.SetActive(false);

            CheckTimeScale();

            if (Input.GetKey("space") || Input.GetKey("joystick button 0"))
            {
                isButtonPressed = true;
            }
            else
            {
                isButtonPressed = false;
            }

            transform.position = new Vector2(transform.position.x, transform.position.y + textScrollSpeed * Time.deltaTime);
        }
        else
        {
            isStopEndRoll = true;
            //　エンドロールが終了した時
            if (isStopEndRoll == true && count > 1 && BText == true)
            {
                Time.timeScale = 1.0f;
                endRollCoroutine = StartCoroutine(GoToNextScene());
            }
        }


    }
    IEnumerator GoToNextScene()
    {
        //　1秒間待つ
        yield return new WaitForSeconds(2.0f);

        BText.SetActive(true);
        //ホワイトアウト後シーン遷移
        if (Input.GetKeyDown("space") || Input.GetKeyDown("joystick button 0"))
        {

            Debug.Log("button");
            FadeController2.isFadeOut = true;
            white.SendMessage("WhiteOut");
            StopCoroutine(endRollCoroutine);
            Invoke("title",3.5f);
        }
    }

    void title()
    {
        SceneManager.LoadScene("Prologue");
    }

    void CheckTimeScale()
    {
        // スケール格納用ローカル変数
        float newTimeScale = 1.0f;

        if (isButtonPressed)
        {
            // ボタンが押されている間は早送りする
            newTimeScale = scale;
        }
        // Unity世界の時間にスケールを適用
        Time.timeScale = newTimeScale;
    }
  
    void EndRoll()
    {
        isStopEndRoll = false;
    }
}