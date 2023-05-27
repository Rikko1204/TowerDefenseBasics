using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Cannon : Turret
{

    public override void Shoot()
    {
        GameObject GO = (GameObject)Instantiate(turretProjectilePrefab, firingPoint.position, firingPoint.rotation);
        CannonBall cannonBall = GO.GetComponent<CannonBall>();

        if (cannonBall != null)
        {
            cannonBall.Seek(target);
        }
    }

}
