using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//課題点　死体がある時の挙動　二個載せたときの挙動
public class erebata2 : MonoBehaviour
{
    private int j;
    private int z;
    private int y;
    private int i1;
    private int q;
    private int g;
    private int v;
    // Start is called before the first frame update
    void Start()
    {
        j = 0;
        z = 0;
        y = 0;
        i1 = 0;
        q = 0;
        g = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
            if (erebehan2.j == 1 && erebehan2.i == 2)
            {
                g = 1;
                Invoke("mori", 0.1f);

            }

            if (erebehan2.i == 2 && q == 0 && erebehan2.j == 0)
            {
                q = 1;
                Invoke("ori", 1f);
            }

            if (erebehan2.j == 1 && q == 0 && erebehan2.i == 0)
            {
                q = 1;
                Invoke("nori", 1f);
            }

            if (i1 == 1)
            {
                if (y <= 412)
                {
                    this.transform.position += new Vector3(0, -0.005f, 0);
                    y++;
                }
                else
                {
                    y = 0;
                    erebehan2.j = 0;
                    q = 0;
                    i1 = 0;
                }
            }
            if (i1 == 2)
            {
                if (y <= 412)
                {
                    this.transform.position += new Vector3(0, 0.005f, 0);
                    y++;
                }
                else
                {
                    y = 0;
                    erebehan2.i = 0;
                    q = 0;
                    i1 = 0;
                }
            }
            if (erebehan2.v == 2 && q == 0)
            {
                q = 1;
                Invoke("kuri", 1f);
            }
            if (v == 1)
            {
                if (y <= 412)
                {
                    this.transform.position += new Vector3(0, 0.005f, 0);
                    y++;
                }
                else
                {
                    y = 0;
                    q = 0;
                    erebehan2.v = 0;
                    v = 0;
                }
            }
        

    }
    void nori()
    {
        if (g == 1)
        {
            erebehan2.i = 0;
            erebehan2.j = 0;
            q = 0;
            g = 0;
        }
        else
        {
            i1 = 1;
            g = 0;
        }
    }
    void ori()
    {
        if (g == 1|| erebehan2.v == 1)
        {
            erebehan2.i = 0;
            erebehan2.j = 0;
            q = 0;
            g = 0;
        }
        else
        {
            i1 = 2;
            g = 0;
        }
    }
    void mori()
    {
        erebehan2.i = 0;
        erebehan2.j = 0;
    }
    void kuri()
    {
        v = 1;
    }
}
