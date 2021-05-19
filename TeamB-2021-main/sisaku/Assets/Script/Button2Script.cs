using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2Script : MonoBehaviour
{
    public GameObject ConectObject2;
    Vector3 objectpos2;
    //効果音
    public AudioClip buttonSound;
    // Start is called before the first frame update
    void Start()
    {
        objectpos2 = ConectObject2.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 goposY = new Vector3(objectpos2.x, objectpos2.y + 3, 0);
            ConectObject2.transform.position = (goposY);
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
