using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextDisplay : MonoBehaviour
{
    //作やすひろ 
    public Text StartText;
    [SerializeField] GameObject secondText;
    public int TextTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        //DelayMethodを3.5秒後に呼び出す
        Invoke("DelayMethod", 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DelayMethod()
    {    
        StartText.gameObject.SetActive(false);
        secondText.gameObject.SetActive(true);
        Invoke("DelayMethods", 2.5f); 
    }
    void DelayMethods()
    {
        secondText.gameObject.SetActive(false);
        TextTime = 1;
    }
}
