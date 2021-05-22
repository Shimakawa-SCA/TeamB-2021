using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class erebeta : MonoBehaviour
{
    private int j; 
 
    private int y;
    // Start is called before the first frame update
    void Start()
    {
        j=0;
       
        y=0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(erebehan1.i == 1) {
            j = 0;
            if(y <= 20625) { 
            this.transform.position += new Vector3(0, 0.01f, 0);
            y+=100;
            }
        }
        
        
        if(erebehan2.i == 1 ) {
            y=0;
            if(j <= 20625) {
                this.transform.position += new Vector3(0, 0.01f, 0);
                j += 100;
            }
        }
    }    
}
