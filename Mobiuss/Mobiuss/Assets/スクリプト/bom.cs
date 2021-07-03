using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bom : MonoBehaviour
{
    private int i;
    public static int n;
    public GameObject CubePrefab;
    //GameObject player;
    float pdis;
    float blx;
    float pdistans;
    bool itemposition;
    bool PlayerRight;
    Rigidbody rb;
    Quaternion q;
    bool canhold;
    //爆発エフェクト的なパーティクル
    public GameObject particleObject;
    [SerializeField] private GameObject BomYY;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        n = 0;
        itemposition = false;
        rb = GetComponent<Rigidbody>();
        q = Quaternion.Euler(0, 0, 0);
        //player = GameObject.Find("New Sprite");
        BomYY.SetActive(false);
        canhold = true;
    }

    private void Update()
    {
        if (rb.velocity.x > 2.5) rb.velocity = new Vector3(0,0,0);
        pdis = (Mathf.Abs(transform.position.x - Pass.PlayerPosition.x) + Mathf.Abs(transform.position.y - Pass.PlayerPosition.y));
        //Debug.Log(pdis);
        if (Mathf.Abs(this.transform.position.x) > 8.5f) transform.position = new Vector3(blx, transform.position.y);
        blx = this.transform.position.x;
        PlayerRight = Pass.PlayerRight;
        if (pdis < 1)
        {
            if (itemposition == false)
            {
                BomYY.SetActive(true);
            }
            if ((Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown("joystick button 1")) && itemposition == false && canhold == true && Pass.RespawnStack == false)
            {
                NewSoundScriot.GetItem1 = true;
                itemposition = true;
                Pass.PlayerHold = true;
                BomYY.SetActive(false);
            }
        }
        else
        {
            BomYY.SetActive(false);
        }
        if (itemposition == true)
        {
            if (PlayerRight == true)
            {
                transform.position = new Vector3(Pass.PlayerPosition.x+0.5f, Pass.PlayerPosition.y,0);
            }
            if (PlayerRight == false)
            {
                transform.position = new Vector3(Pass.PlayerPosition.x - 0.5f, Pass.PlayerPosition.y, 0);
            }
        }
        if (itemposition == true && i == 1)
        {
            if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown("joystick button 1"))
            {
                canhold = false;
                NewSoundScriot.UseItem1 = true;
                rb.velocity = new Vector3(0,0,0);
                transform.parent = null;
                itemposition = false;
                BomColor.ColorChange = true; //ボムの点滅
                Debug.Log("4秒後に爆発！！");
                Invoke("ban", 3.5f);
                Pass.PlayerHold = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown("joystick button 2")){
            itemposition = false;
            Pass.PlayerHold = false;
            rb.velocity = new Vector3(0, 0, 0);
        }
        if (i == 1 && itemposition == true){
            BomYY.SetActive(true);
        }
        if (i == 0 == itemposition == true){
            BomYY.SetActive(false);
        }
    }

    void OnCollisionStay(Collision other)
    {
        /*if (other.gameObject.tag == "player")
        {
            //持ったよ！！って意味でパーティクルとか出したい
            //n秒後に爆発
            Debug.Log("6秒後に爆発！！");
            Invoke("ban", 6f);
        }*/
    }
        void  OnTriggerStay(Collider other){
                if (other.gameObject.tag == "bomhantei")
                {
                    i=1;
                }
        }
        void OnTriggerExit(Collider other)
        {
                if (other.gameObject.tag == "bomhantei")
                {
                    i = 0;
                }
        }

            // Update is called once per frame
        void ban()
        {
            //爆発エフェクト的なパーティクル
            //パーティクル用ゲームオブジェクト生成
            Instantiate(particleObject, this.transform.position, Quaternion.identity); 
            if (i == 1)
            {
                n=1;
            }
            else
            {
                i=0;
                GameObject iwa = Instantiate(CubePrefab);
                iwa.transform.position = new Vector3(8.05f, -2.05f, 0);
                FindObjectOfType<BomColor>().ColorReset();
            }
            Destroy(this.gameObject);
        }
   
   /* void res()
    {
        Instantiate(CubePrefab, new Vector3(8.05f, -2.05f, 0),q);
    }*/
}
