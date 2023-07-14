using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gear : MonoBehaviour
{
    public abstract void EffectOnTurret(Turret turret);
    public abstract void EffectOnEnemy(Enemy enemy);
}
