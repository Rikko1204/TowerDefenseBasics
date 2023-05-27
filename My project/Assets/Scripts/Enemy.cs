// using System.Collections;
// using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	private Currency _currency;
	private Lives _lives;
	public float speed = 10f;
	public float maxHealth = 100f;
	private float health;
	private int worth = 1;
	private int lifeCost = 1;
	
    private Transform target;

    [Header("Unity Required")] 

    private int wavepointIndex = 0;

    public Image healthBar;
    // we need to initialise it's first target
    void Start()
    {
	    _currency = Currency.currencyManager;
	    _lives = Lives.lifeManager;
	    target = Waypoints.points[0];
        health = maxHealth;
    }

	// Hello world
    // make the enemy move towards waypoint
    void Update()
    {
		//transform <-> this
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * (speed * Time.deltaTime));

		if (Vector3.Distance(transform.position, target.position) <= 0.4f) {
			getNextWaypoint();
		}
    }

    public void takeDamage(float amount)
    {
	    health -= amount;
	    healthBar.fillAmount = health / maxHealth;
	    if (health <= 0)
	    {
		    //die
		    Die();
	    }
    }

	private void getNextWaypoint() {
		if (wavepointIndex >= Waypoints.points.Length - 1) {
			Destroy(gameObject);
			_lives.drain(lifeCost);
			return;
		}
		target = Waypoints.points[++wavepointIndex];
	}

	void Die()
	{
		Destroy(gameObject);
		_currency.gain(worth);
	}
}
