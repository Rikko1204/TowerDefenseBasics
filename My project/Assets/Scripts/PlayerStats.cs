using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static long Money;
    public long startMoney = 500;

    public static int Lives;
    public int startLives = 100;

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
    }
}
