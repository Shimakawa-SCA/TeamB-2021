using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class erehaa : MonoBehaviour
{
    public static int i;
    // Start is called before the first frame update
    void Start()
    {
        i=0;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
           i=1;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
           i=0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
