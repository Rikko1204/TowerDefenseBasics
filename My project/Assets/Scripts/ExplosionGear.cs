using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGear : Gear
{
    //public float setCoolDown = 5f;
    public float explosionRadius;
    public float explosionDamage;
    
    // Because this effect is triggered only upon enemy death,
    // the effect cannot be written here and values have to be
    // passed to the enemy.
    public override void EffectOnEnemy(Enemy enemy)
    {
        enemy.explosionRadius = explosionRadius;
        enemy.explosionDamage = explosionDamage;
        //enemy.isExploding = true;

        Debug.Log("Gear effect on enemy triggered");
    }

    public override void EffectOnTurret(Turret turret)
    {
        Debug.Log("Turret gear effect triggered");
        turret.damage += 50;
    }
}
