using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s2star : MonoBehaviour
{
    public GameObject item_Star;
    float changeRed = 1.0f;
    float changeGreen = 1.0f;
    float cahngeBlue = 1.0f;
    float cahngeAlpha = 0.25f;
    
    // Start is called before the first frame update
    void Start()
    {
        changeRed = 1.0f;
        changeGreen = 1.0f;
        cahngeBlue = 1.0f;
        cahngeAlpha = 0.5f;
        GetComponent<Collider>().isTrigger = true;
        Color color = gameObject.GetComponent<Renderer>().material.color;
        color.a = 0.6f;
        gameObject.GetComponent<Renderer>().material.color = color;
        GetComponent<Material>().color = new Color(changeRed, changeGreen, cahngeBlue, cahngeAlpha);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "star")
        {
            Destroy(other.gameObject);
            //パーティクルとか出したい。
            Invoke("koraidalost", 1.5f);
        }

    }
    void koraidalost() 
    {
        GetComponent<Collider>().isTrigger = false;
        cahngeAlpha = 1f;
        Color color = gameObject.GetComponent<Renderer>().material.color;
        color.a = 1f;
        gameObject.GetComponent<Renderer>().material.color = color;
        GetComponent<Material>().color = new Color(changeRed, changeGreen, cahngeBlue, cahngeAlpha);
    }
    // Update is called once per frame
}
