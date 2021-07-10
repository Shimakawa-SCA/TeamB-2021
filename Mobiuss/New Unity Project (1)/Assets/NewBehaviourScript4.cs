using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript4 : MonoBehaviour
{
    float sum=0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Mathf.PI);
        for(int n=0; n<100; n++)
        {
            sum +=4*(Mathf.Pow(-1,n) / (2*n+1));
        }
        Debug.Log(sum);
    }

    
}
