using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageNumber : MonoBehaviour
{
    [SerializeField] int StagenNumber; 
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 120;
        Pass.StageNumber = StagenNumber;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
