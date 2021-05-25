using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reba3kabeue : MonoBehaviour
{
    private int z;
    private int y;
    // Start is called before the first frame update
    void Start()
    {
        z = 0;
        y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (reba3.i == 1)
        {
            if (z < 180)
            {

                transform.Rotate(new Vector3(0, 0, 0.5f));
                z++;
            }

        }
        if (reba3.i == 0)
        {
            if (z > 0)
            {
                transform.Rotate(new Vector3(0, 0, -0.5f));
                z--;
            }

        }
    }
}