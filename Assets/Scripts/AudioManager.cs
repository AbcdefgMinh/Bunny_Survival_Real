using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    public List<Sound> sounds;

    void Awake()
    {
        instance = this;
    }

    public void Play(Sound.soundType soundtype)
    {
        foreach (var sound in sounds)
        {
            if(sound.soundtype == soundtype)
            {
                sound.Play();
            }
        }
    }

    public Sound PlayLoop(Sound.soundType soundtype)
    {
        foreach (var sound in sounds)
        {
            if (sound.soundtype == soundtype)
            {
               return sound.PlayLoop();
            }
        }

        return null;
    }

    public void Pause(Sound.soundType soundtype)
    {
        foreach (var sound in sounds)
        {
            if (sound.soundtype == soundtype)
            {
                sound.Pause();
            }
        }
    }

    public void Stop(Sound.soundType soundtype)
    {
        foreach (var sound in sounds)
        {
            if (sound.soundtype == soundtype)
            {
                sound.Stop();
            }
        }
    }

}
