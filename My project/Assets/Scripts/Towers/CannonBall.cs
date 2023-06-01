using Enemies;
using UnityEngine;

public class CannonBall : TurretProjectile
{
    public override void HitTarget()
    {
        GameObject hitImpact = (GameObject) Instantiate(hitEffect, target.position, target.rotation);
        Destroy(hitImpact, 2f);
        Destroy(gameObject);
        Enemy enemy = target.GetComponent<Enemy>();
        enemy.TakeDamage(50);
    }
}
