using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    [System.Serializable]
    public class TowerLevel
    {
        public GameObject prefab;
        public int cost;
    }

    public TowerLevel[] towerLevels = new TowerLevel[4];
    public bool isOffensiveTurret;

    [HideInInspector]
    public int currTowerLevel;

    /*
    public GameObject prefab;
    public int cost;

    public GameObject UpgradeToLevel2;
    public int upgradeCostToLevel2;

    public GameObject UpgradeToLevel3;
    public int upgradeCostToLevel3;

    public GameObject UpgradeToLevel4;
    public int upgradeCostToLevel4;
    */


    public float sellAmount(int level)
    {
        return towerLevels[level - 1].cost * 0.5f;
    }
}
