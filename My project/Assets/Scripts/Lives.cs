using System;
using TMPro;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public TextMeshProUGUI text; // there shouldn't be more than one of this
    
    public static Lives lifeManager;

    private void Awake()
    {
        if (lifeManager != null)
        {
            return;
        }

        lifeManager = this;
    }

    void Start()
    {
        text.text = "Lives: " + PlayerStats.Lives;
    }

    public void restore(int amount)
    {
        PlayerStats.Lives += amount;
        text.text = "Lives: " + PlayerStats.Lives;
    }

    public void drain(int amount)
    {
        PlayerStats.Lives -= amount;
        text.text = "Lives: " + PlayerStats.Lives;
    }

    public void updatePlayerLives()
    {
        text.text = "Lives: " + PlayerStats.Lives;
    }
}