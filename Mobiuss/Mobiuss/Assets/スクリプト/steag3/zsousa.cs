using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zsousa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (z.n == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
