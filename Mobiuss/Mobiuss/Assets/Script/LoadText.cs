using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadText : MonoBehaviour
{
    public Text Loadtext;
    // Start is called before the first frame update
    void Start()
    {
        Loadtext.text = "Now Loading";
        Invoke("Second", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void First()
    {
        Loadtext.text = "Now Loading";
        Invoke("Second", 1.0f);

    }
    void Second()
    {
        Loadtext.text = "Now Loading.";
        Invoke("Third", 1.0f);

    }
    void Third()
    {
        Loadtext.text = "Now Loading..";
        Invoke("Fourth", 1.0f);

    }
    void Fourth()
    {
        Loadtext.text = "Now Loading...";
        Invoke("First", 1.0f);

    }

}
