using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeWhite : MonoBehaviour
{
    bool IsFadeOut;//フェードアウトをするかどうか
    public bool IsFade;//フェードの演出をするかどうか
    public float time;//フェードにかかる時間
    Image image;
    [SerializeField] GameObject FadePanel;

    void Start()
    {
        image = this.GetComponent<Image>();
        Invoke("StartFade", 1.0f);
        Invoke("Destroy", 2.0f);
    }

    void Update()
    {
        if (IsFade)
        {
            if (IsFadeOut)
            {
                //フェードアウトの処理
                if (image.color.a < 1) image.color = new Color(0, 0, 0, image.color.a + 1 / (60 * time));
                else image.color = new Color(0, 0, 0, 1);
            }
            else
            {
                //フェードインの処理
                if (image.color.a >= 0) image.color = new Color(255, 255, 255, image.color.a - 1 / (60 * time));
                else image.color = new Color(255, 255, 255, 0);
            }
        }
    }

    public void StartFade(float t, bool fadeout)
    {
        time = t;
        IsFadeOut = fadeout ? true : false;
        if (IsFadeOut) image.color = new Color(0, 0, 0, 0);
        else image.color = new Color(0, 0, 0, 1);
        IsFade = true;
    }
    void Destroy()
    {
        FadePanel.SetActive(false);
    }
}