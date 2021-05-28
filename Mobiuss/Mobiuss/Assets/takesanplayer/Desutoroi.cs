using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desutoroi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.Translate(0,0.01f,0);
            transform.Translate(0, 0.01f, 0);
            transform.Translate(0, 0.01f, 0);
            transform.Translate(0, 0.01f, 0);
            transform.Translate(0, 0.01f, 0);
            GameObject.Destroy(this.gameObject);
        }
    }
}
