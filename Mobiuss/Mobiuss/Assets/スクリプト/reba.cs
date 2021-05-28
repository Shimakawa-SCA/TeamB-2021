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
        Transform myTransform = this.transform;
        if (n == 1)
        {
            if (Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown("joystick button 3"))
            {
                //レバー音
                //NewSoundScriot.Lever1 = true;
                if (i == 0)
                {
                    i=1;
                    myTransform.Rotate(0, 180f,0, Space.World);
                }
                else
                {
                    i=0;
                    myTransform.Rotate(0,  -180f,0, Space.World);
                }
            }
        }
    }
       
       
            
        
    
}
