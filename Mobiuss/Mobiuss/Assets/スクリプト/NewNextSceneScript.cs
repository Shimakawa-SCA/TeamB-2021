using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NewNextSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        SceneManager.LoadScene("Stage2");
    }

    public void OnClickT()
    {
        SceneManager.LoadScene("Prologue");
    }
    public void Stage3()
    {
        SceneManager.LoadScene("stage3");
    }
}
