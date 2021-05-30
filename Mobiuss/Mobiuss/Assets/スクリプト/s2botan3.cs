using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s2botan3 : MonoBehaviour
{
    public static int i;
    public GameObject iwaPrefab;
    int jk = 0;
    private int g;
    // Start is called before the first frame update
    void Start()
    {
        i=0;
        g = 0;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "player" || other.gameObject.tag == "dead")
        {
            if (jk == 0)
            {
                NewSoundScriot.Sound1 = true;
                jk = 1;
            }
            Instantiate(iwaPrefab);
            i=1;
        }
        if (other.gameObject.tag == "dead")
        {
            if (jk == 0)
            {
                NewSoundScriot.Sound1 = true;
                jk = 1;
            }
            Instantiate(iwaPrefab);
            i=1;
            g = 1;
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "player")
        {
            if (g == 1)
            {

            }
            else
            {
                i = 0;
                jk = 0;
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (i == 1)
        {
            if (Input.GetKeyDown("joystick button 2"))
            {
                i=0;
                g = 0;
                jk = 0;
            }
        }
    }
}
