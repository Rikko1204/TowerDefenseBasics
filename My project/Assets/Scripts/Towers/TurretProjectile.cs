using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurretProjectile : MonoBehaviour
{
    private protected Transform target;
    private float speed = 70f;
    public GameObject hitEffect;
    internal float damage;
    internal Action<Enemy> effectOnEnemy;

    // Start is called before the first frame update
    public void Seek(Transform _target, float damageToDeal, Action<Enemy> effect)
    {
        target = _target;
        damage = damageToDeal;
        effectOnEnemy = effect;
    }

    public void Seek(Transform _target, float damageToDeal)
    {
        target = _target;
        damage = damageToDeal;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = Time.deltaTime * speed;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    public Action<Enemy> TriggerEffectOnEnemy()
    {
        return effectOnEnemy; //isn't this null?
    }

    public abstract void HitTarget();

}