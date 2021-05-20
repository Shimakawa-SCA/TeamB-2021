using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kiirobo2 : MonoBehaviour
{
    public static int i = 0;
    public GameObject player;
    float plenge;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "player")
        {
            i = 1;
            Debug.Log("あ");
        }
        if (other.gameObject.tag != "player")
        {
            i = 0;
            Debug.Log("触れてないよ");
        }
    }*/

    /*void OnCollisionExit(Collision other)
        {
        if (other.gameObject.tag == "player")
        { 
            i = 0;
            Debug.Log("触れてないよ");
        }
    }*/

    public void getc(int sss)
    {
        i = sss;
    }
}