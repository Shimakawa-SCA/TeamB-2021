﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp02 : MonoBehaviour
{
    int Lv,Exp;
    // Start is called before the first frame update
    void Start()
    {
      Lv = 2;
      Exp = 50;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(1, 0, 1);
    }
}
