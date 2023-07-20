using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : Turret
{
    public Animator animator;

    public override void Shoot()
    {
        GameObject GO = (GameObject)Instantiate(turretProjectilePrefab, firingPoint.position, firingPoint.rotation);
        CatapultProjectile projectile = GO.GetComponent<CatapultProjectile>();
        //partToRotate.GetComponent<Animator>().Play("CatapultAnimation");
        animator.SetBool("IsShooting", true);
        Invoke("OnIdle", 0.75f);
        

        if (projectile != null)
            //_audioManager.PlaySFX("Cannonball");

        if (gear != null)
        {
            projectile.Seek(target, DamageToDeal(), explosionRadius, gear.EffectOnEnemy);
        }
        else
        {
            projectile.Seek(target, DamageToDeal(), explosionRadius);
        }
    }

    public override float DamageToDeal()
    {
        return currUpgradeLevel * damage * 0.75f;
    }

    void OnIdle()
    {
        animator.SetBool("IsShooting", false);
    }
}
