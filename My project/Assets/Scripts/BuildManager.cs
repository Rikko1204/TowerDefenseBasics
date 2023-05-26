using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // SINGLETON class 
    public static BuildManager builder;
    private GameObject turretToBuild;
    public GameObject cannonPrefab;
    void Awake()
    {
        if (builder != null)
        {
            return;
        }
        builder = this;
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
