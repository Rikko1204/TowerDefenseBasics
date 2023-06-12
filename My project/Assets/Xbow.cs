using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xbow : Turret
{
    public override float DamageToDeal()
    {
        return damage;
    }

    public override void Shoot()
    {
        GameObject GO = (GameObject)Instantiate(turretProjectilePrefab, firingPoint.position, firingPoint.rotation);
        XbowProjectile projectile = GO.GetComponent<XbowProjectile>();

        if (projectile != null)
        {
            projectile.Seek(target, DamageToDeal());
        }
    }
}
