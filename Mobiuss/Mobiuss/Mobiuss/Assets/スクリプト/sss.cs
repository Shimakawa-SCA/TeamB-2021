using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sss : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "iwa")
        {
            //パーティクルとか出したい。
            Invoke("koraidalost", 1.5f);
        }
    }
    void koraidalost()
    {
        GetComponent<Collider>().isTrigger = true;
    }
}
