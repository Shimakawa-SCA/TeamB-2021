using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class y : MonoBehaviour
{
    public static int i;
    public GameObject obj;
    public static int n;
    private int g;
    public GameObject CubePrefab;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        n = 0;
        g = 0;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            n = 1;
            if (g == 0)
            {
                Instantiate(obj);
                g = 1;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            n = 0;
            g = 0;
        }
    }
    void Update()
    {
        if (n == 1)
        {
            if (Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown("joystick button 3"))
            {

                botun.sum += 1;
                i += 1;
            }
        }
    }
}
