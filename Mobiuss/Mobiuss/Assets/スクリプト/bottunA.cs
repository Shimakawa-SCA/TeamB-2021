using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottunA : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (kiirobo2.i == 1)
        {
            Invoke("sagaru", 0f);
        }
        if (kiirobo2.i == 0)
        {
            Invoke("agaru", 0f);
        }
    }
    void sagaru()
    {
        for (int i = 0; i < 100; i++)
        {
            transform.Translate(0, -0.001f, 0);
        }
    }
    void agaru()
    {
        for (int i = 0; i < 100; i++)
        {
            transform.Translate(0, 0.001f, 0);
        }
    }
}
