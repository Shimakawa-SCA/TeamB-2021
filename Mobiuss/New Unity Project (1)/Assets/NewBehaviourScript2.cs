using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       Debug.Log(LogCalc(1024));
        Debug.Log(LogCalc(1000000));
    }

    double LogCalc(int number)
    {
        return Mathf.Log(number,2);
    }
   
}
