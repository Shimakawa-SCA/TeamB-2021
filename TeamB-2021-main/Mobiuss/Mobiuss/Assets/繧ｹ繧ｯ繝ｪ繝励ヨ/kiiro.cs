using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kiiro : MonoBehaviour
{
    public static int i = 0;
    public GameObject CubePrefab;
    public GameObject yukaPrefab;
    void start()
    {
        i=0;
    }
    // Start is called before the first frame update
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "player")
        {
            i = 1;
          /*  Instantiate(CubePrefab);*/
            Instantiate(yukaPrefab);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
