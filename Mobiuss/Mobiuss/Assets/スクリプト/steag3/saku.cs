﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saku : MonoBehaviour
{
    private int i;
    private int v;
    private int g;
    private int z;
    // Start is called before the first frame update
    void Start()
    {
        i=0;
        g=0;
        v=0;
        z=0;
    }

    // Update is called once per frame
    void Update()
    {
       if (elevator.mati == 1&&i==0)
       {
            i=1;
            Invoke("spon",0.3f);
       }
        if (elevator.mati == 0 && i == 1)
        {
            i = 0;
            Invoke("respon", 0.3f);
        }
        if (v == 1)
        {
            if (z == 0)
            {
                z=1;
                transform.Translate(0f, 0f, -5f);
            }
            if (g < 50) { 
            transform.Translate(0f, 0.032f,0f);
            g++;
            }
            else
            {
                v=0;
                g=0;
            }
        }
        if (v == 2)
        {
            if (g < 50)
            {
                transform.Translate(0f, -0.032f, 0f);
                g++;
            }
            else
            {
                v = 0;
                g = 0;
                z=0;
                transform.Translate(0f, 0f, 5f);
            }
        }
    }
    void spon()
    {
        v=1;
    }
    void respon()
    {
        v=2;
    }
}
