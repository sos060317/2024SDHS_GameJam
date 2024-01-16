using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] bgmList;
    public AudioSource bgm;
    public AudioClip[] sfxlist;
    public AudioSource sfx;

    private float bgmVolume;
    private float sfxVolume;

    public static AudioManager Instance { get; private set; }
    public void Awake()
    {   
        if (null == Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void Start()
    {

        bgm.Play();
    }

    public void SfxPlay(int index)
    {
        sfx.clip = sfxlist[index];
        sfx.Play();
    }

    public void SetBGMVolume(float volume)
    {
        bgm.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {

    }


    public void ChangeBGM(int index)
    {
        bgm.Stop();
        bgm.clip = bgmList[index];
        bgm.Play();
    }
}