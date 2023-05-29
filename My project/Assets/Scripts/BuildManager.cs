using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // SINGLETON class 
    public static BuildManager Builder;
    private GameObject turretToBuild;
    public GameObject cannonPrefab;
    void Awake()
    {
        if (Builder != null)
        {
            return;
        }
        Builder = this;
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
