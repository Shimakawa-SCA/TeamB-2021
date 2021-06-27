using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takestar2Script : MonoBehaviour
{
    public GameObject player;
    Vector3 playerposition;
    float pdis;
    float pdiss;
    float blx;
    bool ch;
    bool PlayerRight;
    bool pih;
    public static Vector3 sttp;
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
        playerposition = Pass.PlayerPosition;
        if (prs == true) prs = false;
        if (Pass.RespawnStack == true) prs = true;
        if ((prs == true) && (ch == true)) ch = false;
        sttp = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        PlayerRight = Pass.PlayerRight;
        pih = Pass.PlayerHold;
        pdis = (Mathf.Abs(transform.position.x - playerposition.x) + Mathf.Abs(transform.position.y - playerposition.y));
        pdiss = Mathf.Abs(pdis);
        Debug.Log("s2" + pdiss);
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
                    transform.position = new Vector3(playerposition.x + 0.5f, playerposition.y, 0);
                }
                if (PlayerRight == false)
                {
                    transform.position = new Vector3(playerposition.x - 0.5f, playerposition.y, 0);
                }
            }
        }
        if (Mathf.Abs(this.transform.position.x) > 8.5f) transform.position = new Vector3(blx, transform.position.y);
        blx = this.transform.position.x;
    }
    
}
