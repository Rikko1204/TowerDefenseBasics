using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI roundsSurvived;

    private void OnEnable()
    {
        roundsSurvived.text = "You Reached Round: " + PlayerStats.Rounds;
    }
}
