using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iwa : MonoBehaviour
{
    int n = 0;
    public Vector2 SPEED = new Vector2(0.05f, 0.05f);
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
     
    }

    // Update is called once per frame
    void Update()
    {
        if (aka.i == 1&&n==0)
        {
            //n++;
            //Position.x += 10;
            rb.velocity = new Vector3(3f, -1f, 0);
            Invoke("chengetag",1.8f);
        }
    }

    void chengetag()
    {
        gameObject.tag = ("Flor");
    }
}
