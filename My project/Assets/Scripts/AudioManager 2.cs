using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] musicSounds;
    public Sound[] sfxSounds;
    public AudioSource musicSource;
    public AudioSource sfxSource;
    private Sound inPlayMusic;

    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } 
        else
        {
            Destroy(gameObject);
            return;
        }
        
        /*
        foreach (Sound s in musicSounds)
        {
            //s.source = gameObject.AddComponent<AudioSource>();
            musicSource.clip = s.clip;
            musicSource.volume = s.volume;
            musicSource.pitch = s.pitch;
            musicSource.loop = s.loop;            
        }

        foreach (Sound s in sfxSounds)
        {
            //s.source = gameObject.AddComponent<AudioSource>();
            sfxSource.clip = s.clip;
            sfxSource.volume = s.volume;
            sfxSource.pitch = s.pitch;
            sfxSource.loop = s.loop;
        }
        */
    }

    void Start()
    {
        PlayMusic("MainMenu");
    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Audio " +  name + " does not exist");
            return;
        }
        /*
        if (inPlayMusic != null)
        {
            inPlayMusic.source.Stop();
        }
        inPlayMusic = s;
        */
        musicSource.clip = s.clip;
        musicSource.Play();
        
        
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("SFX " + name + " does not exist");
            return;
        }
        sfxSource.PlayOneShot(s.clip);
        //s.source.Play();
    }

    
    public void Pause()
    {
        musicSource.Pause();
        sfxSource.Pause();
    }

    public void Unpause()
    {
        musicSource.UnPause();
        sfxSource.UnPause();
    }
    
    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
