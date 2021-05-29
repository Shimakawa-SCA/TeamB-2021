using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desutoroi : MonoBehaviour
{

    bool rs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rs == true) rs = false;
        if ((TakesanPlayerScript1.respornstack == true) || (TakesanPlayerScript2.respornstack == true) || (TakesanPlayerScript3.respornstack == true)) rs = true;
        if (rs == true)
        {
            transform.Translate(0,0.01f,0);
            transform.Translate(0, 0.01f, 0);
            transform.Translate(0, 0.01f, 0);
            transform.Translate(0, 0.01f, 0);
            transform.Translate(0, 0.01f, 0);
            GameObject.Destroy(this.gameObject);
        }
    }
}
