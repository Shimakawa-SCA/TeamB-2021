using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    int sum= 0;

    // Start is called before the first frame update
    void Start()
    {
        Sum(1, 10);
    }

    // Update is called once per frame
   
        void Sum(int startNumber,int endNumber)
    {
        int[ ] sum = new int [11];
         sum[0]= 0;
        for (int i = startNumber; i <= endNumber; i +=1)
        {
            sum[i] = sum[i-1] +i;
            Debug.Log(sum[i]+",");
        }
       
      
    }
}
