using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class erebehan2 : MonoBehaviour
{
    public static int i;
    public static int j;
    private int z;
    public static int v;
    // Start is called before the first frame update
    void Start() {
        i = 0;
        j = 0;
        z = 0;
        v = 0;
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "player") {
            j = 1;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            z = 1;
        }
    }
    void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "player") {
            i = 2;
            z = 0;
        }
    }
  
    void Update()
    {
        if (z == 1)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                v +=1;
            }
        }
    }
}
