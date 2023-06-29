using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [Header("Slider Elements")]
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider ffSlider;
    [SerializeField] private TextMeshProUGUI ffMultiplierText;
    [SerializeField] private Button masterVolumeButton;
    [SerializeField] private Button sfxVolumeButton;
    //[SerializeField] private Image musicEnabledImage;
    [SerializeField] private Sprite newImage;
    public static string FfMultiplier; // just for ease of autocomplete.
    private AudioManager _audioManager;

    private void Start()
    {
        _audioManager = AudioManager.instance;
        
        // Initialise Slider Values
        var f = PlayerPrefs.GetFloat(FfMultiplier);

        ffMultiplierText.text = "Fast Forward Multiplier: " + f;

        ffSlider.value = f;
        musicSlider.value = _audioManager.musicSource.volume;
        sfxSlider.value = _audioManager.sfxSource.volume;
        
        // Initialise other settings here
        //masterVolumeButton.GetComponent<Image>();
        //sfxVolumeButton.image = musicDisabledImage;
    }

    public void Return()
    {
        gameObject.SetActive(false);
        
        try
        {
            var returnCanvas = CanvasStack.StackOfCanvas.Pop();
            returnCanvas.SetActive(true);
        }
        catch (InvalidOperationException)
        {
            return;
        }

        //_audioManager.Unpause();
    }

    public void SetFastFwdFactor()
    {
        var multiplier = ffSlider.value;
        PlayerPrefs.SetFloat(FfMultiplier, multiplier);
        ffMultiplierText.text = "Fast Forward Multiplier: " +
                                PlayerPrefs.GetFloat(FfMultiplier);
    }

    public void ToggleMusic()
    {
        _audioManager.ToggleMusic();

        Sprite temp = masterVolumeButton.image.sprite;
        masterVolumeButton.image.sprite = newImage;
        newImage = temp;

        /*
        if (masterVolumeButton.image == musicEnabledImage)
        {
            masterVolumeButton.image = musicDisabledImage;
        }
        else
        {
            masterVolumeButton.image = musicEnabledImage;
        }
        */
    }

    public void ToggleSFX()
    {
        _audioManager.ToggleSFX();

        Sprite temp = sfxVolumeButton.image.sprite;
        sfxVolumeButton.image.sprite = newImage;
        newImage = temp;

        /*
        if (sfxVolumeButton.image == musicEnabledImage)
        {
            sfxVolumeButton.image = musicDisabledImage;
        }
        else
        {
            sfxVolumeButton.image = musicEnabledImage;
        }
        */
    }

    public void MusicVolume()
    {
        _audioManager.MusicVolume(musicSlider.value);
    }

    public void SFXVolume()
    {
        _audioManager.SFXVolume(sfxSlider.value);
    }
}
