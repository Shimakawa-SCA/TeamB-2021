using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reba : MonoBehaviour
{
    public static int i ;
    private int n;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        n=0;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            n =1;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            n = 0;
        }
    }

    void Update()
    {
        if (n == 1)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                if (i == 0)
                {
                    i=1;
                }
                else
                {
                    i=0;
                }
            }
        }
    }
       
       
            
        
    
}
