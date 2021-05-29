using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kami : MonoBehaviour
{
    public static int i; 
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown("joystick button 1"))
        {
          i = 0;
          Destroy(gameObject);
          
        }
    }
}
