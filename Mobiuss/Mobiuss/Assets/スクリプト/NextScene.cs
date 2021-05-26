using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ImageEx.NextSceneCount == 1 && Input.GetKey("space") || ImageEx.NextSceneCount == 1 && Input.GetKeyDown("joystick button 0"))
        {
            FadeController.isFadeOut = true;
            Invoke("next",2.0f);
        }
    }

    void next()
    {
        SceneManager.LoadScene("SampleScene"); 
    }
}
