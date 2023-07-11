using UnityEngine;
using UnityEngine.UI;

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
        if (countDown <= 0) {
            currency.Gain(gainAmount);
            countDown = setCountDown;

            GameObject effect = (GameObject) Instantiate(gainEffect, transform.position, transform.rotation);
            Destroy(effect, 2f);

            //Debug.Log("Gain $" + gainAmount);
        }
        
        {
            countDown -= Time.deltaTime;
        }
        //cooldownBar.fillAmount = countDown / setCountDown;
    }
}

