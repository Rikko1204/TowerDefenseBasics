using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [Header("Unity setup")] 
    public static BuildManager builder;
    private GameObject turretToBuild;

    [Header("Turret types")]
    public GameObject cannonPrefab;
    public GameObject blasterPrefab;
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
