using System;
using UnityEngine;
using UnityEngine.UI;
using System;

/*
 * The Mine generates income DURING rounds
 * Ideally it should generate a fixed amount per round
 * spread across the length of the round
 * Ticks per round: 2
 * Income per tick: 5
 * (NOT CORRECTLY IMPLEMENTED YET)
 */

public class Mine : UtilityTurret

{
    private Currency currency;
    private float _localCountDown;
    [Header("Unity setup")]
    private static float _countDown = 20f; // we want all mines to generate $ on the same tick
    public GameObject gainEffect;
    public int gainAmount = 3;
    public int ticks = 3;
    public static bool RoundInProgress = false;
    public Image cooldownBar;

    public override void Start()
    {
        WaveSpawner.startNextWave += StartNewRound; // subscribes to StartNextWave event.
        WaveSpawner.EndWave += EndWave;
        transform.RotateAround(transform.position, transform.up, 180f);
        transform.Rotate(-90, 0, 0);
        _localCountDown = _countDown;
        currency = Currency.currencyManager;
    }

    private void StartNewRound(float totalTimeOfRound)
    {
        _countDown = totalTimeOfRound / ticks;
        _localCountDown = _countDown;
        RoundInProgress = true;
        Debug.Log("The countdown is" + _countDown + " seconds long");
    }

    private void EndWave()
    {
        RoundInProgress = false;
        Debug.Log("Round Ended");
    }

    public override void Update()
    {
        if (_localCountDown <= 0) {
            currency.Gain(gainAmount);
            _localCountDown = _countDown;

            GameObject effect = (GameObject) Instantiate(gainEffect, transform.position, transform.rotation);
            Destroy(effect, 2f);

            //Debug.Log("Gain $" + gainAmount);
        }

        if (RoundInProgress)
        {
            _localCountDown -= Time.deltaTime;
        }
        //cooldownBar.fillAmount = countDown / setCountDown;
    }

    public void OnDestroy()
    {
        WaveSpawner.startNextWave -= StartNewRound;
    }
}

