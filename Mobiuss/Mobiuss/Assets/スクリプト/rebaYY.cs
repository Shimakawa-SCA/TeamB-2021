using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rebaYY : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (reba.n == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
