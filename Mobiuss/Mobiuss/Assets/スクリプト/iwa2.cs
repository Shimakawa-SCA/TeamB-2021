using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iwa2 : MonoBehaviour
{
    Vector3 kyp;
    int n = 0;
    float x;
    int j=0;
    public GameObject iwaPrefab;
    private Rigidbody rb;
    // Start is called before the first frame update
    //　出現させるエフェクト
    [SerializeField]
    private GameObject effectObject;
    //　エフェクトを消す秒数
    [SerializeField]
    private float deleteTime;
    //　エフェクトの出現位置のオフセット値
    [SerializeField]
    private float offset;
    void Start()
    {
        kyp = new Vector3(-5.194008f, -2.634925f, 14.32001f);
        rb = GetComponent<Rigidbody>();
        n=0;
        aka2.i=0;
        x=3;
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "snowwall")
        {
           
            var instantiateEffect = GameObject.Instantiate(effectObject, transform.position + new Vector3(0f, offset, 0f), Quaternion.identity) as GameObject;
            Destroy(instantiateEffect, deleteTime);
            GameObject iwa = Instantiate(iwaPrefab);
            iwa.transform.position = new Vector3(7.209985f, 1.822106f, -0.192756f);
            Destroy(gameObject);
        } 
    }
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Floryuka")
        {
           j=1;
          
        }
    }
            // Update is called once per frame
            void Update()
    {
        if (aka2.i == 1&&j==0)
        {
            //n++;
            //Position.x += 10;
            rb.velocity = new Vector3(-3f, -3f, 0);
        }
        if (j == 1) {
            x *= 0.9965f;
        /*if (x < 1.2)
        {
            x = 0;
        }*/
        rb.velocity = new Vector3(-x , -3f, 0);
        }
        if (transform.position.x < kyp.x){
            rb.velocity = new Vector3(0,rb.velocity.y,0);
        }
    }
}
