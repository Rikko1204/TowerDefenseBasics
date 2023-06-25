using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] sounds;
    private Sound inPlayMusic;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } 
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        PlayNext("MainMenu");
    }
    public void PlayNext(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Audio name " +  name + " does not exist");
            return;
        }

        if (inPlayMusic != null)
        {
            inPlayMusic.source.Stop();
        }
        
        s.source.Play();
        inPlayMusic = s;
        
    }

    public void ProjectileSoundOverlay(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Audio name " + name + " does not exist");
            return;
        }
        s.source.Play();
    }

    public void Pause()
    {
        inPlayMusic.source.Pause();
    }

    public void Play()
    {
        inPlayMusic.source.UnPause();
    }
}
