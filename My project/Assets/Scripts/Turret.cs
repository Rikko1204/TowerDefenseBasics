using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Turret : MonoBehaviour
{
    // Originally named cannon
    [Header("Attributes")]
    public float turnSpeed = 10f;
    public float firingRate = 1f;
    public float firingCountdown = 0f;
    public float range = 5f;

    [Header("Unity setup")]
    public GameObject turretProjectilePrefab;
    public Transform firingPoint;
    private protected Transform target;
    private string enemyTag = "Enemy";


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.1f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = int.MaxValue;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            Vector3 dir = enemy.transform.position - transform.position;
            if (dir.magnitude < shortestDistance)
            {
                shortestDistance = dir.magnitude;
                nearestEnemy = enemy;
            }

            if (nearestEnemy != null && shortestDistance <= range)
            {
                target = nearestEnemy.transform;
            }
            else
            {
                target = null;
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (target == null) { return; }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (firingCountdown <= 0)
        {
            Shoot();
            firingCountdown = 1f / firingRate;
        }
        firingCountdown -= Time.deltaTime;
    }

    public abstract void Shoot();

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

