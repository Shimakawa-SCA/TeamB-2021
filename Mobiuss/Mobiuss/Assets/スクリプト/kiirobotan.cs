using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kiirobotan : MonoBehaviour
{
    private Rigidbody rb;
    private float n;
    // Start is called before the first frame update
    void Start()
    {
        n=0;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (kiiro.i == 1)
        {
            n = transform.position.y;
            if (n <= -1.931f)
            {
                rb.velocity = new Vector3(0, 15f, 0);
                n = transform.position.y;
            }
            else
            {
                rb.velocity = new Vector3(0, 0, 0);
            }
        }

    }
}
