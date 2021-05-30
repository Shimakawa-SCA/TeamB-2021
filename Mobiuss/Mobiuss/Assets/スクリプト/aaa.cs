using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aaa : MonoBehaviour
{
    public GameObject item_Star;
    // Start is called before the first frame update
    void Start()
    {

        GetComponent<Collider>().isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (s2star.i == 1)
        {
            GetComponent<Collider>().isTrigger = false;
        }
    }
}
