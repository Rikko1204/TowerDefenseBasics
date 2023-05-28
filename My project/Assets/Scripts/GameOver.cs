using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI roundsSurvived;
    // when this Panel is first enabled, it will display rounds survived.
    private void OnEnable()
    {
        roundsSurvived.text = "You Reached Round: " + PlayerStats.Rounds;
    }
}
