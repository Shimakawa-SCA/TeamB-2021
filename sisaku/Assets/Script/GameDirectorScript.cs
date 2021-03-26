using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirectorScript : MonoBehaviour
{
    public GameObject Player;
    Vector3 GPos;
    Quaternion q;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        GPos = new Vector3(0, -2, 0);
        q = Quaternion.Euler(0, 0, 0);
        Instantiate(Player, GPos, q);
        FindObjectOfType<PlayerScript>().getnnumber();
        FindObjectOfType<PlayerScript>().getnext();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            FindObjectOfType<PlayerScript>().getnext();
            Instantiate(Player, GPos, q);
            i += 1;
            Debug.Log(i);
        }
        
    }
}
