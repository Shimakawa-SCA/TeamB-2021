using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s2hantei : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bom.n == 1)
        {
            Destroy(this.gameObject);
        }
    }
}
