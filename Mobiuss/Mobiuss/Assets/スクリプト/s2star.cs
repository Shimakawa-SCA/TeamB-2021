using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s2star : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "star")
        {
            Destroy(other.gameObject);
            //パーティクルとか出したい。
            Invoke("koraidalost", 1.5f);
        }

    }
    void koraidalost() 
    {
        GetComponent<Collider>().isTrigger = false;
    }
    // Update is called once per frame
}
