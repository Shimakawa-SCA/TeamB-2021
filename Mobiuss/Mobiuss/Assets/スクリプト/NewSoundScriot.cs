﻿using System.Collections;
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
    public AudioClip lever;
    public static bool Lever1;
    public AudioClip getItem;
    public static bool GetItem1;
    public AudioClip useItem;
    public static bool UseItem1;
    public AudioClip titleButton;
    public static bool TitleButton1;
    public AudioClip revive;
    public static bool Revive1;
    public AudioClip floor;
    public static bool Floor1;
    public AudioClip downDoor;
    public static bool DownDoor1;
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
        Lever1 = false;
        GetItem1 = false;
        UseItem1 = false;
        TitleButton1 = false;
        Revive1 = false;
        Floor1 = false;
        DownDoor1 = false;
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
        if (Lever1 == true)
        {
            audioSource.PlayOneShot(lever);
            Lever1 = false;
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
        if (Revive1 == true)
        {
            audioSource.PlayOneShot(revive);
            Revive1 = false;
        }
        if (Floor1 == true)
        {
            audioSource.PlayOneShot(floor);
            Floor1 = false;
        }
        if (DownDoor1 == true)
        {
            audioSource.PlayOneShot(downDoor);
            DownDoor1 = false;
        }
    }


}
