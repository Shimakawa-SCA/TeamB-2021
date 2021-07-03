using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((saku.o == 1&& elevator_1.play==1)|| (elevator_2.play==1&& saku.o == 1))
        {
            Pass.PlayerCanMove = false;
        }
       else if(TimeCounter.tTime ==1)
        {
            Pass.PlayerCanMove = true;
        }
    }
}
