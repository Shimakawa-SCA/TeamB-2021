using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeSystem : MonoBehaviour
{
    
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }
    //ホワイトアウト実行
    public void WhiteOut()
    {
        GetComponent<Image>().enabled = true;
        animator.SetTrigger("Out");
    }
    //アニメーション制御
    public void EndFadeOutAnimaition()
    {
        GetComponent<Image>().enabled = false;
    }
    //ホワイトアウト後シーン遷移
    public void CoverControll()
    {
        GameObject Co = GameObject.Find("Cover");
        Co.GetComponent<Image>().enabled = true;

        GameObject BoEd = GameObject.Find("bookEd");
        BoEd.SetActive(false);
        //SceneManager.LoadScene("title");
    }


}
