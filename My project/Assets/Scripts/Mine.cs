using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Mine : UtilityTurret


{
    private Currency currency;
    private float countDown;
    [Header("Unity setup")]
    public float setCountDown = 20f;
    public GameObject gainEffect;
    public int gainAmount = 10;
    public Image cooldownBar;


    public override void Start()

    {
        transform.RotateAround(transform.position, transform.up, 180f);
        transform.Rotate(-90, 0, 0);
        countDown = setCountDown;
        currency = Currency.currencyManager;
    }

    public override void Update()
    {
        var canActivate = WaveSpawner.TrackCoroutines.Count > 0;
        if (countDown <= 0 && canActivate) {
            currency.Gain(gainAmount);
            countDown = setCountDown;

            GameObject effect = (GameObject) Instantiate(gainEffect, transform.position, transform.rotation);
            Destroy(effect, 2f);

            //Debug.Log("Gain $" + gainAmount);
        }
        if (canActivate)
        {
            countDown -= Time.deltaTime;
        }
        //cooldownBar.fillAmount = countDown / setCountDown;
    }
}

