using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ObjectChangeEventStream;

public class BuildManager : MonoBehaviour
{
    // SINGLETON class
    [Header("Unity setup")]
    public static BuildManager Builder;
    public Shop Shop;
    internal TurretBlueprint turretToBuild;
    public bool canBuild { get { return turretToBuild != null; } }
    public bool hasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    void Awake()
    {
        if (Builder != null)
        {
            return;
        }
        Builder = this;
    }

    public void SetTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurret(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money");
            Builder.deselectTurret();
            return;
        }

        GameObject instance = (GameObject) Instantiate(turretToBuild.prefab, node.PositionToBuild(), Quaternion.identity);
        node.turret = instance;
        node.nodeOccupied = true;

        PlayerStats.Money -= turretToBuild.cost;
        Debug.Log("$" + PlayerStats.Money + " left");

        Builder.deselectTurret();
    }

    public void deselectTurret()
    {
        Builder.SetTurretToBuild(null);
        Shop.selected = false;
    }
}
