using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp03 : MonoBehaviour
{
    int Lv,Exp;
    // Start is called before the first frame update
    void Start()
    {
      Lv = 3;
      Exp = 100;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(1, 0, 1);
    }
}
