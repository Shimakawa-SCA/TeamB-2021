﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takestar2Script : MonoBehaviour
{
    public GameObject player;
    float pdis;
    bool ch;
    bool PlayerRight;
    bool pih;
    public static Vector3 sttp;
    // Start is called before the first frame update
    void Start()
    {
        ch = false;
        pih = false;
    }

    // Update is called once per frame
    void Update()
    {
        sttp = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        PlayerRight = TakesanPlayerScript2.PlayerRight;
        pih = TakesanPlayerScript2.Hold;
        pdis = ((Mathf.Abs(transform.position.x) - Mathf.Abs(player.transform.position.x)) + (Mathf.Abs(transform.position.y) - Mathf.Abs(player.transform.position.y)));
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
