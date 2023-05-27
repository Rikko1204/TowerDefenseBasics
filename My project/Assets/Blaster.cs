using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : Turret
{
    public Transform secondFiringPoint;
    public override void Shoot()
    {
        GameObject GO = (GameObject)Instantiate(turretProjectilePrefab, firingPoint.position, firingPoint.rotation);
        CannonBall cannonBall = GO.GetComponent<CannonBall>();

        GameObject GO2 = (GameObject)Instantiate(turretProjectilePrefab, secondFiringPoint.position, secondFiringPoint.rotation);
        CannonBall cannonBall2 = GO2.GetComponent<CannonBall>();

        if (cannonBall != null)
        {
            cannonBall.Seek(target);
            cannonBall2.Seek(target);
        }
    }
}
