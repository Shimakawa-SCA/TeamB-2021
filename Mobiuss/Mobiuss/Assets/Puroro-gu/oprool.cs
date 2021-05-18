
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
    private float textScrollSpeed = 30;
    //　テキストの制限位置
    [SerializeField]
    private float limitPosition = 730f;
    //　エンドロールが終了したかどうか
    private bool isStopOpRoll;
    //　シーン移動用コルーチン
    private Coroutine opRollCoroutine;

    private void Start()
    {
        cou++;
        Debug.Log(cou);
        isStopOpRoll = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.Space)||Input.GetButtonDown("1"))
        {
            
        }*/
        //　オープニングロール用テキストがリミットを越えるまで動かす
        if (transform.position.y <= limitPosition&&cou>0)
         {
            OpText.SetActive(false);
            
            transform.position = new Vector2(transform.position.x, transform.position.y + textScrollSpeed * Time.deltaTime);
         }
         else
         {
            isStopOpRoll = true;
            OpText.SetActive(true);
            cou++;
            
            Debug.Log(cou);
            //　エンドロールが終了した時
            if (isStopOpRoll == true && cou > 1/*||Input.GetButtonDown("1")*/)
            {
                Debug.Log("d");
                opRollCoroutine = StartCoroutine(GoGameScene());
            }
        }
        
    }
    IEnumerator GoGameScene()
    {

        OpText.SetActive(true);

        if (check==0 && Input.GetKeyDown("space")/*||Input.GetButtonDown("1")*/)
        {
            check = 1;
            Brack.SendMessage("BrackOut");

            StopCoroutine(opRollCoroutine);
        }

        yield return null;
    }
}