using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class erebata2 : MonoBehaviour
{
    private int j;
    private int z;
    private int y;
    private int i1;
    private int q;
    // Start is called before the first frame update
    void Start()
    {
        j = 0;
        z = 0;
        y = 0;
        i1 = 0;
        q = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (erebehan2.i == 1 && q == 0)
        {
            q = 1;
            Debug.Log("おい！！");
            Invoke("nori", 1f);
        }
        if (erebehan2.i == 2 && q == 0)
        {
            q = 1;
            Invoke("ori", 1f);
        }
        if (i1 == 1)
        {
            if (y <= 206)
            {
                this.transform.position += new Vector3(0, -0.01f, 0);
                y++;
            }
            else
            {
                y = 0;
                erebehan2.i = 0;
                q=0;
                i1 = 0;
            }
        }
        if (i1 == 2)
        {
            if (y <= 206)
            {
                this.transform.position += new Vector3(0, 0.01f, 0);
                y++;
            }
            else
            {
                y = 0;
                erebehan2.i = 0;
                q=0;
                i1 = 0;
            }
        }

    }
    void nori()
    {
        i1 = 1;
    }
    void ori()
    {
        i1 = 2;
    }
}
