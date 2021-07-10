using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 v1 = new Vector3(1,2,3);
        Vector3 v2 = new Vector3(4,5,6);
        Debug.Log(InnerProduct(v1,v2));
    }

    float InnerProduct(Vector3 vec1, Vector3 vec2)
    {
        float calc =0;
        calc=vec1.x*vec2.x
            +vec1.y*vec2.y
            +vec1.z*vec2.z;

    }
   
}
