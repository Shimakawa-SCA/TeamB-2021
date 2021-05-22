using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takestar1Script : MonoBehaviour
{
    public GameObject player;
    float pdis;
    bool ch;
    bool PlayerRight;
    bool pih;
    public static Vector3 stop;
    // Start is called before the first frame update
    void Start()
    {
        ch = false;
        pih = false;
    }

    // Update is called once per frame
    void Update()
    {
        stop = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        PlayerRight = NewPlayer3Script.PlayerRight;
        pih = NewPlayer3Script.Hold;
        pdis = ((transform.position.x - player.transform.position.x) + (transform.position.y - player.transform.position.y));
        if (pdis < 1)
        {
            if (Input.GetKeyDown(KeyCode.I) && (pih == false))
            {
                ch = true;
            }
            if (ch == true)
            {
                if (PlayerRight == true)
                {
                    transform.position = new Vector3(player.transform.position.x + 0.5f, player.transform.position.y, 0);
                }
                if (PlayerRight == false)
                {
                    transform.position = new Vector3(player.transform.position.x - 0.5f, player.transform.position.y, 0);
                }
            }
        }
    }


    
}
