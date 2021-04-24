using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kiirobotan : MonoBehaviour
{
    int j ;
    // Start is called before the first frame update
    void Start()
    {
        j=0;
        transform.Rotate(new Vector3(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
       
        if (kiiro.i == 1)
        {
           
            if (j < 900) { 
                transform.Rotate(new Vector3(0, 0, -0.2f));
                j+=2;
            }

        }
    }
}
