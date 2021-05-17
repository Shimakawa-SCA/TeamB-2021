using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kiro2 : MonoBehaviour
{
    public static int i = 0;
    private float j = 0;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        j = 0;
        i = 0;
    }
    void Update()
    {
        j = transform.position.y;
        if (kiirobo2.i == 1)
        {
            
            if (j >= -1.514)
            {
                rb.velocity = new Vector3(0, -5f, 0);
                j = transform.position.y;
            }
            else
            {
                rb.velocity = new Vector3(0, 0, 0);
            }
        }
        if (kiirobo2.i == 0)
        {
            if (j <= 1.315) 
            {
                rb.velocity = new Vector3(0, 5f, 0);
                j = transform.position.y;

            }
            else
            {
                rb.velocity = new Vector3(0, 0, 0);
            }
        }

        // Update is called once per frame
    }
}
