using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;

    public bool isOffensiveTurret;

    [HideInInspector]
    public bool isUpgraded;

    public float sellAmount()
    {
        if (isUpgraded)
        {
            return upgradeCost * 0.5f;
        } 
        else
        {
            return cost * 0.5f;
        }
        
    }
}
