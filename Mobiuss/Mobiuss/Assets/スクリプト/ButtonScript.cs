using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public int num;
    public GameObject ConectObject;
    public GameObject addblock;
    public float x;
    public float y;
    public bool Move_x;
    public bool Move_y;
    public bool Destory;
    public bool RollRock;
    public bool AddBlock;
    Vector3 objectpos;
    Rigidbody CORB;
    //効果音
    public AudioClip buttonSound;
    // Start is called before the first frame update
    void Start()
    {
        CORB = ConectObject.GetComponent<Rigidbody>();
        CORB.constraints = RigidbodyConstraints.FreezePosition;
        objectpos = ConectObject.transform.position;
        addblock.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Move_x == true)
            {
                Vector3 goposX = new Vector3(objectpos.x + x, objectpos.y, 0);
                ConectObject.transform.position = (goposX);
            }
            if (Move_y == true)
            {
                Vector3 goposY = new Vector3(objectpos.x, objectpos.y + y, 0);
                ConectObject.transform.position = (goposY);
            }
            if (Destory == true)
            {
                ConectObject.SetActive(false);
            }
            if (RollRock == true)
            {
                CORB.constraints = RigidbodyConstraints.None;
                CORB.velocity = new Vector3(2f, 0, 0);
            }
            if (AddBlock == true)
            {
                addblock.SetActive(true);
            }
        }
    }
    //効果音を触れた瞬間だけ鳴らすため
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(buttonSound, Camera.main.transform.position);
        }
    }
}
