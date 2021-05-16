using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kimidori : MonoBehaviour
{
    public static int i = 0;
    public GameObject CubePrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(CubePrefab);
    }
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "player")
        {
            i = 1;
            
            Destroy(gameObject);
            Invoke("DelayMethod", 0.5f);
        }

       
    }
    void DelayMethod()
    {
        i=0;
    }
}
