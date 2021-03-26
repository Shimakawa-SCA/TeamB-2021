using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody rb;
    public bool Jon;
    int mynumber;
    int nownumber;
    public GameDirectorScript GetGameDirectorScript;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Jon = false;
        mynumber = 0;
        nownumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (mynumber == nownumber)
        {
            float nspeed = Mathf.Abs(rb.velocity.x);
            if (nspeed < 2)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    rb.AddForce(2f, 0, 0);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    rb.AddForce(-2f, 0, 0);
                }
            }
            if (Input.GetKeyDown(KeyCode.Space) && (Jon == false))
            {
                rb.velocity = new Vector3(rb.velocity.x, 5, 0);
                Jon = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Flor")) Jon = false;
        
    }

    public void getnnumber()
    {
        mynumber += 1;
    }

    public void getnext()
    {
        nownumber += 1;
    }
}
