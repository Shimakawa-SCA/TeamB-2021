using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getplayerScript : MonoBehaviour
{
    float pd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(pd);
        if(pd < 0 && pd > -0.3)
        {
            FindObjectOfType<kiirobo2>().getc(1);
        }
        else
        {
            FindObjectOfType<kiirobo2>().getc(0);
        }
        if(Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown("joystick button 2"))
        {
            Invoke("repd",0.1f);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if ((other.gameObject.tag == "player") || (other.gameObject.tag == "dead"))
        {
            pd = ((transform.position.x - 0.1f - other.transform.position.x) +(transform.position.y + 0.3f -other.transform.position.y));
        }
    }

     public void repd()
    {
        pd = 0;
    }
    void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "player") || (other.gameObject.tag == "dead"))
        {
            NewSoundScriot.Sound1 = true;
        }
    }
   
}
