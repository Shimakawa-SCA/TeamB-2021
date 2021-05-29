using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aka2 : MonoBehaviour
{
    public static int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "player")
        {
            NewSoundScriot.Sound1 = true;
            i = 1;
            Debug.Log("i=1");
        }

    }
    // Update is called once per frame
    void Update()
    {
       
        
        
    }
}
