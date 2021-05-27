using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botun : MonoBehaviour
{
    public static int sum;
    public GameObject CubePrefab;
    public AudioClip audioClip1;
    public AudioClip audioClip2;
    private AudioSource audioSource;
    private int v;
    // Start is called before the first frame update
    void Start()
    {
        sum = 0;
        v = 0;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sum == 1)
        {

            if (x.i == 1 && y.i == 0 && z.i == 0 && o.i == 0)
            {
                audioSource.clip = audioClip1;
                audioSource.Play();
            }
            else
            {
                Invoke("outu", 0f);
            }
            
        }
        if (sum == 2)
        {

            if (x.i == 1 && y.i == 1 && z.i == 0 && o.i == 0)
            {
                audioSource.clip = audioClip1;
                audioSource.Play();
            }
            else
            {
                Invoke("outu", 0f);
            }

        }
        if (sum == 3)
        {

            if (x.i == 1 && y.i == 1 && z.i == 1 && o.i == 0)
            {
                audioSource.clip = audioClip1;
                audioSource.Play();
            }
            else
            {
                Invoke("outu", 0f);
            }

        }
        if (sum ==4 && v == 0)
        {

            if (x.i == 1 && y.i == 1 && z.i == 1 && o.i == 1)
            {
                audioSource.clip = audioClip1;
                audioSource.Play();
                Instantiate(CubePrefab);
                v = 1;
            }
            else
            {
                //これで行けると思う
                //outu()
                Invoke("outu", 0f);
            }

        }
    }
    void outu()
    {
        //失敗を知らせる効果音
        //初期化
        audioSource.clip = audioClip2;
        audioSource.Play();
        x.i = 0;
        y.i = 0;
        z.i = 0;
        o.i = 0;
        sum = 0;
    }
}
