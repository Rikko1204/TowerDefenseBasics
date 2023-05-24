using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // SINGLETON class 
    public static BuildManager builder;
    private GameObject turretToBuild;
    void Awake()
    {
        if (builder != null)
        {
            return;
        }
        builder = this;
    }

    public GameObject standardTurretPrefab;

    private void Start()
    {
        turretToBuild = standardTurretPrefab;
    }

    public GameObject getTurretToBuild()
    {
        return turretToBuild;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
