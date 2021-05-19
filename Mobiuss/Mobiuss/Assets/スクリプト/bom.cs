using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bom : MonoBehaviour
{
    private int i;
    public static int n;
    public GameObject CubePrefab;
    public GameObject player;
    float pdis;
    float pdistans;
    bool itemposition;
    bool PlayerRight;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        n = 0;
        itemposition = false;
    }

    private void Update()
    {
        pdis = ((transform.position.x - player.transform.position.x) + (transform.position.y - player.transform.position.y));
        Debug.Log(pdis);
        FindObjectOfType<NewPlayer3Script>().setcanhold(pdis);
        if (pdis < 1)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                itemposition = true;
            }
        }
        if (itemposition == true)
        {
            if (PlayerRight == true)
            {
                transform.position = new Vector3(player.transform.position.x+0.5f,player.transform.position.y,0);
            }
            if (PlayerRight == false)
            {
                transform.position = new Vector3(player.transform.position.x - 0.5f, player.transform.position.y, 0);
            }
        }
        if (itemposition == true && i == 1)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                transform.parent = null;
                itemposition = false;
            }
        }

    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "player")
        {
            //持ったよ！！って意味でパーティクルとか出したい
            //n秒後に爆発
            Debug.Log("6秒後に爆発！！");
            Invoke("ban", 6f);
        }
    }
        void  OnTriggerStay(Collider other){
                if (other.gameObject.tag == "hantei")
                {
                    i=1;
                }
        }
        void OnTriggerExit(Collider other)
        {
                if (other.gameObject.tag == "hantei")
                {
                    i = 0;
                }
        }

            // Update is called once per frame
        void ban()
        {
            //爆発エフェクト的なパーティクル
            
            if (i == 1)
            {
                    n=1;
            }
            else
            {
                i=0;
                GameObject iwa = Instantiate(CubePrefab);
                iwa.transform.position = new Vector3(8.05f, -2.05f, 0);
            }

        Destroy(this.gameObject);

    }
  
    public void getright(bool pr)
    {
        PlayerRight = pr;
    }
}
