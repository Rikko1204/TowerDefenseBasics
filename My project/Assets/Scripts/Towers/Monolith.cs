using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monolith : Turret
{
    public override void Shoot()
    {
        GameObject GO = (GameObject)Instantiate(turretProjectilePrefab, firingPoint.position, firingPoint.rotation);
        MonolithProjectile projectile = GO.GetComponent<MonolithProjectile>();

        if (projectile != null)
            //_audioManager.PlaySFX("Cannonball");

        if (gear != null)
        {
            projectile.Seek(target, DamageToDeal(), gear.EffectOnEnemy);
        }
        else
        {
            projectile.Seek(target, DamageToDeal());
        }
    }

    public override float DamageToDeal()
    {
        if (isUpgraded)
        {
            return damage * 1.5f;
        }
        else
        {
            return damage;
        }
    }
}
