using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Turret : Buildings
{
    [Header("Attributes")]
    public float turnSpeed = 10f;
    public float firingRate = 1f;
    public float firingCountdown = 0f;
    public float range = 5f;
    public float damage = 50;
    public float explosionRadius = 0f;

    [Header("Unity setup")]
    public GameObject turretProjectilePrefab;
    public Transform firingPoint;
    public Transform partToRotate;
    private protected Transform target;
    private string enemyTag = "Enemy";
    internal bool isUpgraded = false;
    internal bool isEquipped = false;
    internal Gear gear;
    internal AudioManager _audioManager;


    // Start is called before the first frame update
    public override void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.1f);
        _audioManager = AudioManager.instance;
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
    public override void Update()
    {
        if (target == null)
        {
            // your cannon should still cooldown even if it's not shooting
            firingCountdown = Mathf.Max(0, firingCountdown - Time.deltaTime);
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (firingCountdown <= 0)
        {
            if (partToRotate != null)
            {
                partToRotate.Rotate(75, 0, 0);
            }
            Shoot();
            firingCountdown = 1f / firingRate;

            if (partToRotate != null)
            {
                partToRotate.Rotate(-75, 0, 0);
            }
        }
        firingCountdown -= Time.deltaTime;


        // Test
        if (gear == null)
        {
            //gear.UseAbility();
        }
    }

    public abstract void Shoot();
    public abstract float DamageToDeal();

    public void TriggerGearEffect(Gear gear)
    {
        this.gear = gear;
        isEquipped = true;
        gear.EffectOnTurret(this);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

