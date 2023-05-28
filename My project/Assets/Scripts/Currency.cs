using System;
using TMPro;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public TextMeshProUGUI text; // there shouldn't be more than one of this

    public static Currency currencyManager;

    void Awake()
    {
        if (currencyManager != null)
        {
            return;
        }
        currencyManager = this;
    }

    void Start()
    {
        text.text = "$ " + PlayerStats.Money;
    }

    public void Gain(int amount)
    {
        PlayerStats.Money += amount;
        text.text = "$ " + PlayerStats.Money;
    }

    public void Spend(int amount)
    {
        PlayerStats.Money -= amount;
        text.text = "$ " + PlayerStats.Money;
    }

    public void UpdatePlayerMoney()
    {
        text.text = "$ " + PlayerStats.Money;
    }
}
