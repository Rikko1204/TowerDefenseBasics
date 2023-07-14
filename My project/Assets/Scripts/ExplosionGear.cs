using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGear : Gear
{
    //public float setCoolDown = 5f;
    public float explosionRadius = 10f;
    public float explosionDamage;
    
    // Because this effect is triggered only upon enemy death,
    // the effect cannot be written here and values have to be
    // passed to the enemy.
    
    

    public override void EffectOnTurret(Turret turret)
    {
        Debug.Log("Turret gear effect triggered");
        turret.damage *= 1.1f;
    }

    // Can we force the enemy to subscribe to a DeathEvent?
    public override void EffectOnEnemy(Enemy enemy)
    {
        Collider[] hitTargets = Physics.OverlapSphere(enemy.transform.position, explosionRadius);
        foreach (Collider hitTarget in hitTargets)
        {
            if (hitTarget.CompareTag("Enemy"))
            {
                Enemy caughtInExplosion = hitTarget.GetComponent<Enemy>();
                if (caughtInExplosion == enemy)
                {
                }
                else
                {
                    caughtInExplosion.TakeDamage(caughtInExplosion.maxHealth * 0.1f);
                }
            }
        }
    }
}
