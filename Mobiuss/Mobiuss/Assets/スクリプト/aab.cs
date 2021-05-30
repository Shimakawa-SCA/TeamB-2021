using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aab : MonoBehaviour
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
        if (star33.i == 1)
        {
            GetComponent<Collider>().isTrigger = false;
        }
    }
}
