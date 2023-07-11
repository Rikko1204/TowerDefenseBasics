using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SlowTurret : UtilityTurret
{
    [Header("Attributes")]
    public float range = 10f;
    public float slowness = 0.5f;

    [Header("Unity setup")]
    private string enemyTag = "Enemy";

    public override void Start()
    {
        InvokeRepeating("slowEnemy", 0f, 0.05f);
    }
    public override void Update()
    {
        
    }

    public void slowEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        foreach (GameObject enemy in enemies)
        {
            Vector3 dir = enemy.transform.position - transform.position;
            Enemy enemyIns = enemy.GetComponent<Enemy>();
            if (dir.magnitude < range)
            {
                enemyIns.slowDown(slowness);
            }
            else
            {
                enemyIns.normalSpeed();
            }
        }
    }
}
