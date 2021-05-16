using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kiirobotan : MonoBehaviour
{
    private int n;
    // Start is called before the first frame update
    void Start()
    {
        n=0;
    }

    // Update is called once per frame
    void Update()
    {
        if (kiiro.i == 1)
        {
             if(n<9000 ){
                n+=15;
            transform.Rotate(new Vector3(0, 0, -0.15f));
             }
        }

    }
}
