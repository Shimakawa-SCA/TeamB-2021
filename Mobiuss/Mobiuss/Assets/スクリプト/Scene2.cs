using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene2 : MonoBehaviour
{
    // Use this for initialization
    public void OnClick()
    {
        SceneManager.LoadScene("stage1");
    }
}