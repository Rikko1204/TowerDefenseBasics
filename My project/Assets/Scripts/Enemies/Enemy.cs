using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IHasAbility
{
	//DO NOT CHANGE: PlayerStats Functionality depends on this
	private Currency _currency;
	private Lives _lives;

	//DO NOT CHANGE: Enemy Pathing AI functionality
	private Transform _target;
	private int _wavepointIndex = 0;

	[Header("Enemy Attributes")]
	public float speed = 10f;

	public float maxHealth = 100f;

	public int worth = 1; // Gold Dropped upon kill

	public int lifeCost = 1; // Lives deducted upon exit

	private protected float Health;

	public float damageMultiplier;
	
	[Header("Ability usage parameters")]	
	public float timeBetweenAbility = 3.0f;

	public float countDown = 5.0f;

	[Header("Unity Required")] 
	public Image healthBar;

	
	public void Start()
	{
		// PlayerStats
		_currency = Currency.currencyManager;
		_lives = Lives.LifeManager;
		
		// Enemy AI
		_target = Waypoints.points[0];
		
		// Enemy Health Setup
		Health = maxHealth;
	}

	void Update()
	{
		// Enemy Pathing AI 
		Vector3 dir = _target.position - transform.position;
		transform.Translate(dir.normalized * (speed * Time.deltaTime));

		if (Vector3.Distance(transform.position, _target.position) <= 0.4f) {
			GetNextWaypoint();
		}

		// Ability Usage Timing
		if (countDown <= 0)
		{
			UseAbility();
			countDown = timeBetweenAbility;
		}
		else
		{
			countDown -= Time.deltaTime;
		}
	}

	public virtual void TakeDamage(float amount)
	{
		Health -= amount;
		healthBar.fillAmount = Health / maxHealth;
		if (Health <= 0)
		{
			//die
			Die();
		}
	}

	private void GetNextWaypoint() {
		if (_wavepointIndex >= Waypoints.points.Length - 1) {
			Destroy(gameObject);
			_lives.drain(lifeCost);
			return;
		}
		_target = Waypoints.points[++_wavepointIndex];
	}

	private protected void Die()
	{
		Destroy(gameObject);
		_currency.Gain(worth);
	}

	public virtual void UseAbility()
	{
		// Do nothing
	}
	
}
