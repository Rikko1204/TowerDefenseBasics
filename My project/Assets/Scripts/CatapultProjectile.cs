using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultProjectile : TurretProjectile
{
    public override void HitTarget()
    {
        GameObject hitImpact = (GameObject)Instantiate(hitEffect, target.position, target.rotation);
        Destroy(hitImpact, 2f);
        Destroy(gameObject);

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Enemy enemy = collider.GetComponent<Enemy>();
                enemy.TakeDamage(damage);
                enemy.TakeEffectFromGear(TriggerEffectOnEnemy());
            }
        }

    }
}
