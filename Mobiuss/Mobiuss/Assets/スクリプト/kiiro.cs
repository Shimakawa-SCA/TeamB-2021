using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kiiro : MonoBehaviour
{
    public static int i = 0;
    public GameObject CubePrefab;
    int j;
    // Start is called before the first frame update
    void Start()
    {
        i=0;
        j = 0;
    }
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "player" || other.gameObject.tag == "dead")
        {
            i = 1;
            Instantiate(CubePrefab);
            j = 1;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (j > 0)
        {
            j ++;
            if (j > 1)
            {
                Destroy(gameObject);
            }
        }
    }
}
