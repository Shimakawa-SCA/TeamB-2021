using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s2botan3 : MonoBehaviour
{
    public static int i;
    public GameObject iwaPrefab;
    // Start is called before the first frame update
    void Start()
    {
        i=0;
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "player"&&i==0)
        {
            Instantiate(iwaPrefab);
            i=1;
        }

    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "player")
        {
            i=0;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
