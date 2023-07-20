using UnityEngine;

public class Cannon : Turret
{

    public override void Shoot()
    {
        GameObject GO = (GameObject)Instantiate(turretProjectilePrefab, firingPoint.position, firingPoint.rotation);
        CannonBall cannonBall = GO.GetComponent<CannonBall>();

        if (cannonBall != null)
            _audioManager.PlaySFX("Cannonball");

            if (gear != null)
            {
                cannonBall.Seek(target, DamageToDeal(), gear.EffectOnEnemy);
            }
        else
            {
                cannonBall.Seek(target, DamageToDeal());
            }
    }

    public override float DamageToDeal()
    {
        return currUpgradeLevel * damage * 0.75f;
    }

}

