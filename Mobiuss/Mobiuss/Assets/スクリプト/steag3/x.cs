using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class x : MonoBehaviour
{
    public static int i;
    private int n;
    public GameObject CubePrefab;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        n = 0;
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
        if (n == 1)
        {
            if (Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown("joystick button 3"))
            {
                 
                botun.sum += 1;
                i = 1;
            }
        }
    }
}
