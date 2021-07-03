using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage3hako : MonoBehaviour
{
    public float pdis;
    bool playerhold;
    bool latehold;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        playerhold = false;
        latehold = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (playerhold == true){
            if (Pass.PlayerRight == true)
            {
                this.transform.position = new Vector3(Pass.PlayerPosition.x + 0.5f, Pass.PlayerPosition.y, 0);
            }
            if (Pass.PlayerRight == false)
            {
                this.transform.position = new Vector3(Pass.PlayerPosition.x - 0.5f, Pass.PlayerPosition.y, 0);
            }
        }
        pdis = (Mathf.Abs(transform.position.x - Pass.PlayerPosition.x) + Mathf.Abs(transform.position.y - Pass.PlayerPosition.y));
        if (pdis < 1)
        {
            if (latehold == false){
                if ((Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown("joystick button 1"))){
                    NewSoundScriot.GetItem1 = true;
                    playerhold = true;
                    Pass.PlayerHold = true;
                }
            }
        }
        if (latehold == true){
            if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown("joystick button 1"))
            {
                playerhold = false;
                Pass.PlayerHold = false;
                rb.velocity = new Vector3(0,0,0);
            }
        }
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown("joystick button 2")){
            Pass.PlayerHold = false;
            playerhold = false;
            rb.velocity = new Vector3(0, 0, 0);
        }
            latehold = playerhold;
    }
}
