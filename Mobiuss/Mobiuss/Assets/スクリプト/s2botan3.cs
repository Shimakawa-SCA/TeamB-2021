using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s2botan3 : MonoBehaviour
{
    public static int i;
    public GameObject iwaPrefab;
    int jk = 0;
    // Start is called before the first frame update
    void Start()
    {
        i=0;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "player"|| other.gameObject.tag == "dead")
        {
            if(jk == 0)
            {
                NewSoundScriot.Sound1 = true;
                jk = 1;
            }
            Instantiate(iwaPrefab);
            i++;
        }

    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "player")
        {
            i--;
            jk = 0;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (i == 1)
        {
            if (Input.GetKeyDown("joystick button 2"))
            {
                i --;
                jk = 0;
            }
        }
    }
}
