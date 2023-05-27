using System;
using TMPro;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public TextMeshProUGUI text; // there shouldn't be more than one of this

    public static Currency currencyManager;

    private void Awake()
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

    public void gain(int amount)
    {
        PlayerStats.Money += amount;
        text.text = "$ " + PlayerStats.Money;
    }

    public void spend(int amount)
    {
        PlayerStats.Money -= amount;
        text.text = "$ " + PlayerStats.Money;
    }

    public void updatePlayerMoney()
    {
        text.text = "$ " + PlayerStats.Money;
    }
}
