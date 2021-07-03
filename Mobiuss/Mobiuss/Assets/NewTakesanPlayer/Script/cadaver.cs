using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cadaver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Pass.PlayerCanMove == true){
            if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown("joystick button 2")){
                Destroy(this.gameObject);
            }
        }
    }
}
