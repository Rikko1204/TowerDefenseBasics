using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XbowProjectile : TurretProjectile
{
    public override void HitTarget()
    {
        GameObject hitImpact = (GameObject)Instantiate(hitEffect, target.position, target.rotation);
        Destroy(hitImpact, 1f);
        Destroy(gameObject);
        Enemy enemy = target.GetComponent<Enemy>();
        enemy.TakeDamage(damage);
    }
}
