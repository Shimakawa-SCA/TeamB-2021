using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s2yuka3 : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "iwa")
        {
            Invoke("yuka", 0.5f);
        }
    }


    // Update is called once per frame
    void yuka()
    {
        rb.velocity = new Vector3(0, -5f, 0);
    }
}