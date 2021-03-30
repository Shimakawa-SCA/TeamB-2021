using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextDisplay : MonoBehaviour
{
    //作やすひろ
    public Text StartText;
    // Start is called before the first frame update
    void Start()
    {
        //DelayMethodを3.5秒後に呼び出す
        Invoke("DelayMethod", 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DelayMethod()
    {
        StartText.gameObject.SetActive(false);
    }
}
