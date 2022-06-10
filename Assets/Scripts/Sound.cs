using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Sound : MonoBehaviour
{
    public enum soundType
    {
        mainmenu,
        gameplay,
        button,
        luckybox,
        getitem,
        pickitem,

    }

    public float volume;
    public float pitch;
    public soundType soundtype;
    public AudioClip audioClip;
    public AudioSource audio;

    public void Start()
    {
        audio.clip = audioClip;
        AudioManager.instance.sounds.Add(this);
    }


    public void Play()
    {
        audio.volume = volume;
        audio.pitch = pitch;
        audio.loop = false;
        audio.Play();
    }

    public Sound PlayLoop()
    {
        audio.volume = volume;
        audio.pitch = pitch;
        audio.loop = true;
        audio.Play();
        return this;
    }

    public void Stop()
    {
        audio.Stop();
    }

    public void Pause()
    {
        audio.Pause();
    }
}
