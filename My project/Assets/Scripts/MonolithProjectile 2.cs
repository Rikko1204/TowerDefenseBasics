using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonolithProjectile : TurretProjectile
{
    public override void HitTarget()
    {
        GameObject hitImpact = (GameObject)Instantiate(hitEffect, target.position, target.rotation);
        Destroy(hitImpact, 2f);
        Destroy(gameObject);
        Enemy enemy = target.GetComponent<Enemy>();
        enemy.TakeDamage(damage);
        enemy.TakeEffectFromGear(TriggerEffectOnEnemy());
    }
}
