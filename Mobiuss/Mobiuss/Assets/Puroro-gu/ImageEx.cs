using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ImageEx : MonoBehaviour
{
    [SerializeField] private GameObject BookImag;
    [SerializeField] private GameObject BooksImag;

    // Start is called before the first frame update
    void Start()
    {
        BookImag.SetActive(true);
        BooksImag.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            BookImag.SetActive(false);
            BooksImag.SetActive(true);
        }
    }
    
}
