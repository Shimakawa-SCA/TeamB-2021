using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator_2 : MonoBehaviour
{
    public static int play;
    public static int dead;
    public static int weit;
    public static int kibako;


    void Start()
    {
        play = 0;
        dead = 0;
        weit = 0;
        kibako = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player"&&play==0)
        {
            weit += 1;
            play = 1;
        }
        if (other.gameObject.tag == "dead"&&dead==0)
        {
           // weit += 1;
            dead = 1;
        }
        if (other.gameObject.tag == "kibako" && kibako == 0)
        {
            weit += 1;
            kibako = 1;
        }
    }
    /*void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            z = 1;
        }
    }*/
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            weit -= 1;
            play = 0;
        }
        if (other.gameObject.tag == "kibako")
        {
            weit -= 1;
            kibako = 0;
        }
    }
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        if (dead == 1)
        {
            if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown("joystick button 2"))
            {
                weit -= 1;
                dead = 0;
            }
        }
       
        if (play == 1)
        {
            if ((Pass.PlayerCanMove == true) && Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown("joystick button 2"))
            {
                //weit -= 1;
                play = 0;
            }

        }
    }
}
