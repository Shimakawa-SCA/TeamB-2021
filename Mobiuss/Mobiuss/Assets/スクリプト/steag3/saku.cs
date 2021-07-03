using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saku : MonoBehaviour
{
   private int i;
    private int v;
    private int z;
    private int g;
    public static int o;
    private int mati;
    bool kirei;
    // Start is called before the first frame update
    void Start()
    {
        i=0;
        g=0;
        v=0;
        z=0;
        o=0;
        mati=0;
        kirei=true;
    }

    // Update is called once per frame
    void Update()
    {
       if (elevator.mati == 1&&i==0&&kirei==true)
       {
            kirei=false;
            i=1;
            Invoke("spon",0.3f);
       }
        if (elevator.mati == 0 && i == 1&&kirei==true)
        {
            kirei=false;
            i = 0;
            Invoke("respon", 0.3f);
        }
        if (v == 1||mati==1)
        {
            mati=1;
            if (z == 0)
            {
                z=1;
                transform.Translate(0f, 0f, -3f);
            }
            if (g < 50) { 
            transform.Translate(0f, 0.032f,0f);
            g++;
            }
            else
            {
                v=0;
                g=0;
                mati=0;
                kirei=true;
            }
        }
        if (v == 2||mati==2)
        {
            mati=2;
            if (g < 50)
            {
                transform.Translate(0f, -0.032f, 0f);
                g++;
            }
            else
            {
                mati=0;
                v = 0;
                g = 0;
                z=0;
                transform.Translate(0f, 0f, 3f);
                o = 0;
                kirei =true;
            }
        }
    }
    void spon()
    {
        v=1;
        o=1;
    }
    void respon()
    {
        v=2;
    
    }
}
