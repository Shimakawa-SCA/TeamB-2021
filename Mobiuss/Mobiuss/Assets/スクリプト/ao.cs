using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ao : MonoBehaviour
{
    // Start is called before the first frame update
    public static int i = 0;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "player")
        {
            i = 1;
            Destroy(gameObject);
        }
    }
}
