using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takestar1Script : MonoBehaviour
{
    public GameObject player;
    float pdis;
    float pdiss;
    float blx;
    bool ch;
    bool PlayerRight;
    bool pih;
    public static Vector3 stop;
    bool prs;
    // Start is called before the first frame update
    void Start()
    {
        ch = false;
        pih = false;
        prs = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (prs == true) prs = false;
        if (Pass.RespawnStack == true) prs = true;
        if ((prs == true) && (ch == true)) ch = false;
        stop = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        PlayerRight = Pass.PlayerRight;
        pih = Pass.PlayerHold;
        pdis = (Mathf.Abs(transform.position.x - Pass.PlayerPosition.x) + Mathf.Abs(transform.position.y - Pass.PlayerPosition.y));
        pdiss = Mathf.Abs(pdis);
        Debug.Log("s1"+pdiss);
        if (pdiss < 1.5)
        {
            if ((Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown("joystick button 1")) && (pih == false) && Pass.RespawnStack == false)
            {
                NewSoundScriot.GetItem1 = true;
                ch = true;
                Pass.PlayerHold = true;
            }
            if (ch == true)
            {
                if (PlayerRight == true)
                {
                    transform.position = new Vector3(Pass.PlayerPosition.x + 0.5f, Pass.PlayerPosition.y, 0);
                }
                if (PlayerRight == false)
                {
                    transform.position = new Vector3(Pass.PlayerPosition.x - 0.5f, Pass.PlayerPosition.y, 0);
                }
            }
        }
        if (Mathf.Abs(this.transform.position.x) > 8.5f) transform.position = new Vector3(blx, transform.position.y);
        blx = this.transform.position.x;
    }

    
}
