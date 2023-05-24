// using System.Collections;
// using System.Collections.Generic;

using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
	public float maxHealth = 100f;
	private float health;
	private int worth = 1;
	
    private Transform target;

    [Header("Unity Required")] 

    private int wavepointIndex = 0;
    // we need to initialise it's first target
    void Start()
    {
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

	    if (health <= 0)
	    {
		    //die
		    Destroy(gameObject);
	    }
    }

	private void getNextWaypoint() {
		if (wavepointIndex >= Waypoints.points.Length - 1) {
			Destroy(gameObject);
			return;
		}
		target = Waypoints.points[++wavepointIndex];
	}
}
