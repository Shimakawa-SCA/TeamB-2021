using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSoundScriot : MonoBehaviour
{

    public AudioClip sound1;
    AudioSource audioSource;
    public static bool Sound1;
    public AudioClip stone;
    public static bool Stone1;
    public AudioClip menu;
    public static bool Menu1;
    public AudioClip menuButton;
    public static bool MenuButton1;
    public AudioClip clear;
    public static bool Clear1;
    public AudioClip gameOver;
    public static bool GameOver1;
    public AudioClip getItem;
    public static bool GetItem1;
    public AudioClip useItem;
    public static bool UseItem1;
    public AudioClip titleButton;
    public static bool TitleButton1;
    public AudioClip jump;
    public static bool Jump1;
    public AudioClip landing;
    public static bool Landing1;
    public AudioClip run;
    public static bool Run1;
    public static int i;

    float atl;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Sound1 = false;
        Stone1 = false;
        Menu1 = false;
        MenuButton1 = false;
        Clear1 = false;
        GameOver1 = false;
        GetItem1 = false;
        UseItem1 = false;
        TitleButton1 = false;
        Jump1 = false;
        Landing1 = false;
        Run1 = false;
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Sound1 == true)
        {
            audioSource.PlayOneShot(sound1);
            Sound1 = false;
        }
        if (Stone1 == true)
        {
            audioSource.PlayOneShot(stone);
            Stone1 = false;
        }
        if (Menu1 == true)
        {
            audioSource.PlayOneShot(menu);
            Menu1 = false;
        }
        if(MenuButton1 == true)
        {
            audioSource.PlayOneShot(menuButton);
            MenuButton1 = false;
        }
        if (Clear1 == true)
        {
            audioSource.PlayOneShot(clear);
            Clear1 = false;
        }
        if (GameOver1 == true)
        {
            audioSource.PlayOneShot(gameOver);
            GameOver1 = false;
        }
        if (GetItem1 == true)
        {
            audioSource.PlayOneShot(getItem);
            GetItem1 = false;
        }
        if (UseItem1 == true)
        {
            audioSource.PlayOneShot(useItem);
            UseItem1 = false;
        }
        if (TitleButton1 == true)
        {
            audioSource.PlayOneShot(titleButton);
            TitleButton1 = false;
        }
        if (Jump1 == true)
        {
            audioSource.PlayOneShot(jump);
            Jump1 = false;
        }
        if (Landing1 == true)
        {
            audioSource.PlayOneShot(landing);
            Landing1 = false;
        }

        
        if (Run1 == true){
            if (atl == 0){
                audioSource.PlayOneShot(run);
                Invoke("x2run",0.25f);
            }
            atl += Time.deltaTime;
            if (atl > 2.2f) atl = 0;
        }
        if (Run1 == false){
            audioSource.Stop();
            atl = 0;
        }
        /*if (Run1 == true)//&&i==0)
        {
            audioSource.PlayOneShot(run);
            //Run1 = false;
                //i++;
        }
        else
        {
            if (i >= 120)
            {
                i=0;
            }
            i++;
        }*/
    }

    /*public void x2run()
    {
        audioSource.PlayOneShot(run);
    }*/
}
