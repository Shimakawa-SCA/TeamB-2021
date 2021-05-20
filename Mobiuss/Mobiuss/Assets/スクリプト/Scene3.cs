using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scene3 : MonoBehaviour
{

    // Use this for initialization
    public void OnClick()
    {
        SceneManager.LoadScene("stage2");
    }
    public void OnClickT()
    {
        SceneManager.LoadScene("Prologue");
    }

}