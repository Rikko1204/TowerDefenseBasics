using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CannonBall : TurretProjectile
{
    public override void HitTarget()
    {
        GameObject hitImpact = (GameObject)Instantiate(hitEffect, target.position, target.rotation);
        Destroy(hitImpact, 2f);

        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}


