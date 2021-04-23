using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kiirobotan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (kiiro.i == 1)
        {
            Destroy(gameObject);
        }

    }
}
