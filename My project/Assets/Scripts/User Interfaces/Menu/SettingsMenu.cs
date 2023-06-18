using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public GameObject homeScreen;
    
    public void GoToHome()
    {
        gameObject.SetActive(false);
        homeScreen.SetActive(true);
    }

    public void FastFwdSettings()
    {
        
    }
}
