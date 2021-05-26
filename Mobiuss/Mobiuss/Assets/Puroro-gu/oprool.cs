
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class oprool : MonoBehaviour
{
    int cou = 0;
    int check = 0; 
    [SerializeField] GameObject OpText;

    public GameObject Brack;

    //　テキストのスクロールスピード
    [SerializeField]
    private float textScrollSpeed = 60;
    //　テキストの制限位置
    [SerializeField]
    private float limitPosition = 730f;
    //　エンドロールが終了したかどうか
    private bool isStopOpRoll;
    //　シーン移動用コルーチン
    private Coroutine opRollCoroutine;

    bool buttonFlag = false;

    [SerializeField]
    float scale = 2.0f;

    bool isButtonPressed = false;

    private void Start()
    {
        cou++;
        Debug.Log(cou);
        isStopOpRoll = false;
    }

    // Update is called once per frame
    void Update()
    {
        //　オープニングロール用テキストがリミットを越えるまで動かす
        if (transform.position.y <= limitPosition&&cou>0)
        {
            OpText.SetActive(false);

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
        else//動きを止める、ボタンテキストを表示
        {
            isStopOpRoll = true;
            Invoke("Optextcre", 2.5f);
            cou = 2;

            Debug.Log(cou);
            //　オープニングロールが終了した時
            if (isStopOpRoll == true && cou > 1 || Input.GetKeyDown("joystick button 0"))
            {
                Time.timeScale = 1.0f;
                Debug.Log("b");
                opRollCoroutine = StartCoroutine(GoGameScene());
            }
        }
    }

    void Optextcre()
    {
        OpText.SetActive(true);
    }

    IEnumerator GoGameScene()
    {

        //Invoke("OproolText",2.0f);
        yield return new WaitForSeconds(1.5f);
        OpText.SetActive(true);

        if (check==0 && Input.GetKeyDown("space")|| check == 0 && Input.GetKeyDown("joystick button 0"))
        {
            check = 1;
            Brack.SendMessage("BrackOut");

            StopCoroutine(opRollCoroutine);
            Invoke("Stage", 3.0f);
        }

        yield return null;
    }

    void Stage()
    {
        SceneManager.LoadScene("Stage1");
    }

    /*void OproolText()
    {
        OpText.SetActive(true);
    }*/

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
}