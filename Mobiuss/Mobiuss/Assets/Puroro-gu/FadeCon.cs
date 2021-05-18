using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FadeCon : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        this.anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BrackOut()
    {
        GetComponent<Image>().enabled=true;
        anim.SetTrigger("Go");
    }

    public void OpFadeOut()
    {
        GetComponent<Image>().enabled = false;
        //SceneManager.LoadScene("MainGame");
    }
}
