using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
    private int iti;
    private int tyek;
    public static int mati;
    public static int y;
    // Start is called before the first frame update
    void Start()
    {
        iti = 2;
        mati = 0;
        tyek = 0;
        y = 0;
    }

    // Update is called once per frame
    void Update()
    {
            if (elevator_2.weit == 1 && elevator_1.weit == 0)
            {
                if (iti == 2 && mati == 0)
                {
                    mati = 1;
                    Invoke("sage", 1f);
                }
                else if (iti == 0 && mati == 0)
                {
                    mati = 1;
                    Invoke("age", 1f);
                }
            }
            if (elevator_2.weit == 2 && elevator_1.weit == 0)
            {
                if (iti == 1 && mati == 0)
                {
                    mati = 1;
                    Invoke("sage", 1f);
                }
            }
            if (elevator_2.weit == 1 && elevator_1.weit == 1)
            {
                if (iti == 1 && mati == 0)
                {
                    mati = 1;
                    Invoke("age", 1f);
                }
            }
            if (elevator_2.weit == 2 && elevator_1.weit == 1)
            {
                if (iti == 2 && mati == 0)
                {
                    mati = 1;
                    Invoke("sage", 1f);
                }
                else if (iti == 0 && mati == 0)
                {
                    mati = 1;
                    Invoke("age", 1f);
                }
            }
            if (elevator_2.weit == 1 && elevator_1.weit == 2)
            {
                if (iti == 2 && mati == 0)
                {
                    mati = 1;
                    Invoke("age", 1f);
                }
            }
            if (elevator_2.weit == 0 && elevator_1.weit == 1)
            {
                if (iti == 1 && mati == 0)
                {
                    mati = 1;
                    Invoke("age", 1f);
                }
            }
            if (elevator_2.weit == 0 && elevator_1.weit == 2)
            {
                if (iti == 1 && mati == 0)
                {
                    mati = 1;
                    Invoke("age", 1f);
                }
            }
            if (elevator_2.weit == 0 && elevator_1.weit == 0)
            {
                if (iti == 1 && mati == 0)
                {
                    mati = 1;
                    Invoke("age", 1f);
                }
            }
        
            if (tyek == 1)
            {
                if (y <= 412)
                {
                    this.transform.position += new Vector3(0, -0.005f, 0);
                    y++;
                }
                else
                {
                    y = 0;
                mati = 0;
                tyek = 0;
                }
            }
            if (tyek == 2)
            {
                if (y <= 412)
                {
                    this.transform.position += new Vector3(0, 0.005f, 0);
                    y++;
                }
                else
                {
                    y = 0;
                    tyek = 0;
                mati = 0;
            }
            }
        
    }
    void sage()
    {
        tyek = 1;
        iti -= 1;

    }
    void age()
    {
        tyek = 2;
        iti += 1;

    }
}
