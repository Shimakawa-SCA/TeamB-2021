using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    double sum =0;

    // Start is called before the first frame update
    void Start()
    {
        for(int i= 1; i< 100 ; i++)
        {
            sum +=3*(i/100.0) * (i/100.0)
                     *(1 / 100.0);
        }
        Debug.Log(sum);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
