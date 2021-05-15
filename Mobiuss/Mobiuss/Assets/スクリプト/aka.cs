using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aka : MonoBehaviour
{
    public static int i=0;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
    }
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "player")
        {
            i = 1;
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
