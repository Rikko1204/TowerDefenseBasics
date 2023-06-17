using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : UtilityTurret
{
    private Currency currency;
    private float countDown;
    [Header("Unity setup")]
    public float setCountDown = 20f;
    public GameObject gainEffect;
    public int gainAmount = 10;

    public override void Start()
    {
        countDown = setCountDown;
        currency = Currency.currencyManager;
    }
    public override void Update()
    {
        if (countDown <= 0) {
            currency.Gain(gainAmount);
            countDown = setCountDown;

            GameObject effect = (GameObject) Instantiate(gainEffect, transform.position, transform.rotation);
            Destroy(effect, 2f);

            //Debug.Log("Gain $" + gainAmount);
        }
        countDown -= Time.deltaTime;
    }
}

