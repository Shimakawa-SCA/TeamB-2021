using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1Script : MonoBehaviour
{
    public GameObject ConectObject1;
    Vector3 objectpos1;
    public GameObject addblock1;
    //効果音
    public AudioClip buttonSound;
    // Start is called before the first frame update
    void Start()
    {
        objectpos1 = ConectObject1.transform.position;
        addblock1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 goposY = new Vector3(objectpos1.x, objectpos1.y + 3, 0);
            ConectObject1.transform.position = (goposY);
            addblock1.SetActive(true);
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
