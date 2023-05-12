// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // public fields are editable in Unity
    public float speed = 10f;

	//Transform a type that contains information about angles, position.
    private Transform target;

    private int wavepointIndex = 0;
    // we need to initialise it's first target
    void Start()
    {
        target = Waypoints.points[0];
    }

    // make the enemy move towards waypoint
    void Update()
    {
		//transform <-> this
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime);

		if (Vector3.Distance(transform.position, target.position) <= 0.4f) {
			getNextWaypoint();
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
