using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kiirobo2 : MonoBehaviour
{
    public static int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            i = i;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "player")
        {
            i = 0;
            // transform.Translate(0, -0.1f, 0);
            Debug.Log("あa");
        }
    }
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "player")
        {

            i = 1;
            // transform.Translate(0, 0.1f, 0);
            Debug.Log("触れてない");
        }
    }
    void OnCollisionExit(Collision other)
        {
        if (other.gameObject.tag == "player")
        { 
            
            i = 0;
           // transform.Translate(0, 0.1f, 0);
            Debug.Log("触れてないよ");
        }
    }

}