using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [Header("Slider Elements")] 
    [SerializeField] private Slider ffSlider;
    [SerializeField] private TextMeshProUGUI ffMultiplierText;
    public static string FfMultiplier; // just for ease of autocomplete.

    private void Start()
    {
        
        // Initialise Slider Values
        var f = PlayerPrefs.GetFloat(FfMultiplier);

        ffMultiplierText.text = "Fast Forward Multiplier: " + f;

        ffSlider.value = f;
        
        // Initialise other settings here
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
    }

    public void SetFastFwdFactor()
    {
        var multiplier = ffSlider.value;
        PlayerPrefs.SetFloat(FfMultiplier, multiplier);
        ffMultiplierText.text = "Fast Forward Multiplier: " +
                                PlayerPrefs.GetFloat(FfMultiplier);
    }
}
