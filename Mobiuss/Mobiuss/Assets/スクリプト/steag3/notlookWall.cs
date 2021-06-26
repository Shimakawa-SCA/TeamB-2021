using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notlookWall : MonoBehaviour
{
    [SerializeField] private GameObject musi;
    // Start is called before the first frame update
    void Start()
    {
        musi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (erehaa.i == 1&&elevator_2.weit!=2)
        {
            musi.SetActive(true);
        }
        else
        {
            musi.SetActive(false);
        }
    }
}
