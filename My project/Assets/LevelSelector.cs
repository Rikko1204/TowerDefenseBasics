using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public SceneFader fader;
    public AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = AudioManager.instance;
    }
    public void SelectLevel(string name)
    {
        fader.FadeTo(name);
        _audioManager.PlayMusic("Battle");
    }
}
