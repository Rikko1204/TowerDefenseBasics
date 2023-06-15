using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGear : Gear
{
    public override void EffectOnEnemy(Enemy enemy)
    {
        Debug.Log("Gear effect on enemy triggered");
    }

    public override void EffectOnTurret(Turret turret)
    {
        Debug.Log("Turret gear effect triggered");
        turret.damage += 50;
    }
}
