using UnityEngine;
using UnityEngine.UI;

namespace Enemies
{
	public class Enemy : MonoBehaviour
	{
		private Currency _currency;
		private Lives _lives;
		public float speed = 10f;
		public float maxHealth = 100f;
		protected float Health;
		private int _worth = 1;
		private int _lifeCost = 1;
	
		private Transform _target;

		[Header("Unity Required")] 

		private int _wavepointIndex = 0;

		public Image healthBar;
		// we need to initialise it's first target
		void Start()
		{
			_currency = Currency.currencyManager;
			_lives = Lives.LifeManager;
			_target = Waypoints.points[0];
			Health = maxHealth;
		}

		// Hello world
		// make the enemy move towards waypoint
		void Update()
		{
			//transform <-> this
			Vector3 dir = _target.position - transform.position;
			transform.Translate(dir.normalized * (speed * Time.deltaTime));

			if (Vector3.Distance(transform.position, _target.position) <= 0.4f) {
				GetNextWaypoint();
			}
		}

		public void TakeDamage(float amount)
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
				_lives.drain(_lifeCost);
				return;
			}
			_target = Waypoints.points[++_wavepointIndex];
		}

		void Die()
		{
			Destroy(gameObject);
			_currency.Gain(_worth);
		}
	}
}
