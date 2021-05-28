using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takestar1Script : MonoBehaviour
{
    public GameObject player;
    float pdis;
    float blx;
    bool ch;
    bool PlayerRight;
    bool pih;
    public static Vector3 stop;
    // Start is called before the first frame update
    void Start()
    {
        ch = false;
        pih = false;
    }

    // Update is called once per frame
    void Update()
    {
        stop = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        PlayerRight = TakesanPlayerScript2.PlayerRight;
        pih = TakesanPlayerScript2.Hold;
        pdis = ((Mathf.Abs(transform.position.x) - Mathf.Abs(player.transform.position.x)) + (Mathf.Abs(transform.position.y) - Mathf.Abs(player.transform.position.y)));
        if (pdis < 1)
        {
            if (Input.GetKeyDown(KeyCode.I) && (pih == false))
            {
                ch = true;
            }
            if (ch == true)
            {
                if (PlayerRight == true)
                {
                    transform.position = new Vector3(player.transform.position.x + 0.5f, player.transform.position.y, 0);
                }
                if (PlayerRight == false)
                {
                    transform.position = new Vector3(player.transform.position.x - 0.5f, player.transform.position.y, 0);
                }
            }
        }
        if (Mathf.Abs(this.transform.position.x) > 8.5f) transform.position = new Vector3(blx, transform.position.y);
        blx = this.transform.position.x;
    }

    
}
