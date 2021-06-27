using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomColor : MonoBehaviour
{
    //点滅させるため
    //public GameObject Bomimage; // 自分のオブジェクト取得用変数
    public static bool ColorChange = true; // trueの場合はフェードイン
    const float EARLINESS = 0.01f;
    int direction = 3;
    float col = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        //点滅させるため
        //Bomimage = this.gameObject; // 自分のオブジェクト取得
        ColorChange = false;
    }

    // Update is called once per frame
    void Update()
    {
        //点滅させるため
        if (ColorChange == true)
        {
            col += EARLINESS * direction;
            if (col >= 1.0f)
            {
                direction = -3;
            }
            if (col <= 0.0f)
            {
                direction = 3;
            }
            this.GetComponent<SpriteRenderer>().color = new Color(1, col, col, 1);
        }
        
    }
    public void ColorReset(){
        this.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
    }
}
