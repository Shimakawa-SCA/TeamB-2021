using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pepar : MonoBehaviour
{
    public static int i;
    public static int n;
    private int v;
    public GameObject CubePrefab;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        n = 0;
        v = 0;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            n = 1;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            n = 0;
        }
    }

    void Update()
    {
        Transform myTransform = this.transform;
        if (i == 1)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (kami.i == 0 && v == 1)
                {
                    Instantiate(CubePrefab);
                    kami.i = 1;
                    v = 0;
                 
                }
                else
                {
                    v = 1;
                }
            }
        }
        if (n == 1)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (i == 0&&kami.i==0)
                {
                    i = 1;
                    Instantiate(CubePrefab);
                    kami.i = 1;
                }
            }
        }
        

    }
}
