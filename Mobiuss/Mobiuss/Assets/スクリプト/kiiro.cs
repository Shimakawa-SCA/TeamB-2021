﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kiiro : MonoBehaviour
{
    public static int i = 0;
    public GameObject CubePrefab;
    // Start is called before the first frame update
    void Start()
    {
        i=0;
    }
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "player")
        {
            //足場が出てくるときの音
            NewSoundScriot.Floor1 = true;
            NewSoundScriot.Sound1 = true;
            i = 1;
            Instantiate(CubePrefab);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
