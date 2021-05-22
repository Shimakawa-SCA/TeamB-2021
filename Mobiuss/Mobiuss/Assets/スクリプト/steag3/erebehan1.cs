using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class erebehan1 : MonoBehaviour
{
    public static int i;

    void Start() {
        i = 0;
    }

    void OnTriggerStay(Collider other) {
        if(other.gameObject.tag == "player") {
            i = 1;
        }
    }
    void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "player") {
            i = 0;
        }

    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
}
