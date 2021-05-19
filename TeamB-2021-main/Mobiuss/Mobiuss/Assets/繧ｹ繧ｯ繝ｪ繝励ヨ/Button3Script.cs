using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button3Script : MonoBehaviour
{
    public GameObject ConectObject3;
    Vector3 objectpos3;
    public GameObject ConectObject31;
    Vector3 objectpos31;
    public GameObject ConectObject32;
    Vector3 objectpos32;
    //効果音
    public AudioClip buttonSound;

    // Start is called before the first frame update
    void Start()
    {
        objectpos3 = ConectObject3.transform.position;
        objectpos31 = ConectObject31.transform.position;
        objectpos32 = ConectObject32.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 goposY = new Vector3(objectpos3.x, objectpos3.y - 2, 0);
            ConectObject3.transform.position = (goposY);
            Vector3 goposY1 = new Vector3(objectpos31.x, objectpos31.y - 2, 0);
            ConectObject31.transform.position = (goposY1);
            Vector3 goposY2 = new Vector3(objectpos32.x, objectpos32.y - 3, 0);
            ConectObject32.transform.position = (goposY2);
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
