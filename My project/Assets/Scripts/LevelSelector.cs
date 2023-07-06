using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public SceneFader fader;
    public AudioManager _audioManager;
    public Button[] levelButtons;

    int levelReached;

    private void Awake()
    {
        _audioManager = AudioManager.instance;
    }

    private void Start()
    {
        levelReached = PlayerPrefs.GetInt("LevelReached", 1);

        for (int i = 0;  i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
        }
    }
    public void SelectLevel(string name)
    {
        fader.FadeTo(name);
        _audioManager.PlayMusic("Battle");
    }
}
