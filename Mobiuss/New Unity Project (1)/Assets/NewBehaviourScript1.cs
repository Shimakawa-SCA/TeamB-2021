using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        float sin = Mathf.Sin(Time.time);
        this.transform.position=new Vector3(sin,0,0);
    }
}
