using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ao : MonoBehaviour
{
    // Start is called before the first frame update
    public static int i = 0;
    public GameObject CubePrefab;
    public GameObject CubePrefab2;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "player")
        {
            i = 1;
            Instantiate(CubePrefab);
            Instantiate(CubePrefab2);
            Destroy(gameObject);
        }
    }
}
