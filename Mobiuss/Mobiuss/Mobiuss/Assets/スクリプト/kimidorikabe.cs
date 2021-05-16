using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kimidorikabe : MonoBehaviour
{
    int n = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (kimidori.i == 1&&n==0)
        {
            Destroy(gameObject);
        }
    }
}
