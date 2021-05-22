using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class erebata2 : MonoBehaviour
{
    private int j;
    private int z;
    private int y;
    // Start is called before the first frame update
    void Start() {
        j = 0;
        z=0;
        y=0;
    }

    // Update is called once per frame
    // Update is called once per frame
    void Update() {

        if(erebehan2.i == 1&&z==0) {
            j = 0;
            if(y <= 20625) {
                this.transform.position += new Vector3(0, -0.01f, 0);
                y +=100;
            } else { 
            z=1;
            }
        }


        if(erebehan1.i == 1&&z==1) {
            y = 0;
            if(j <= 20625) {
                this.transform.position += new Vector3(0, 0.01f, 0);
                j +=100;
            } else {
                z=0;
            }
        }
    }
}

