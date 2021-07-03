using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reba3: MonoBehaviour
{
    public static int i;
    public static int n;
    [SerializeField] private GameObject RebaYYY;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        n = 0;
        RebaYYY.SetActive(false);

    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            n = 1;
            RebaYYY.SetActive(true);

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            n = 0;
            Debug.Log("離れた");
            RebaYYY.SetActive(false);
        }
    }

    void Update()
    {
        Transform myTransform = this.transform;
        if (n == 1)
        {
            if (Input.GetKeyDown(KeyCode.T)|| Input.GetKeyDown("joystick button 3"))
            {
                if (i == 0)
                {
                    i = 1;
                    Debug.Log("来てるよ～～");
                    myTransform.Rotate(0, 180f, 0, Space.World);
                }
                else
                {
                    i = 0;
                    myTransform.Rotate(0, -180f, 0, Space.World);
                }
            }
        }
    }
}
