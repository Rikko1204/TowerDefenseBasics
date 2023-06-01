using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // SINGLETON class
    [Header("Unity setup")]
    public static BuildManager Builder;
    public Shop Shop;
    internal TurretBlueprint turretSelected;
    internal Node nodeSelected;
    public GameObject buildEffect;
    internal bool canBuild { get { return turretSelected != null; } }
    internal bool hasMoney { get { return PlayerStats.Money >= turretSelected.cost; } }

    void Awake()
    {
        if (Builder != null)
        {
            return;
        }
        Builder = this;
    }

    // Either shop turret or node can selected at a time only
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretSelected = turret;
        nodeSelected = null;
    }

    public void SelectNode(Node node)
    {
        nodeSelected = node;
        turretSelected = null;
    }

    public void BuildTurret(Node node)
    {
        if (PlayerStats.Money < this.turretSelected.cost)
        {
            Debug.Log("Not enough money");
            Shop.deselectTurret();
            return;
        }

        GameObject turretToBuildIns = (GameObject) Instantiate(turretSelected.prefab, node.PositionToBuild(), Quaternion.identity);
        GameObject buildEffectIns = (GameObject) Instantiate(buildEffect, node.PositionToBuild(), Quaternion.identity);

        node.turretOnNode = turretToBuildIns;
        node.nodeOccupied = true; 
        Destroy(buildEffectIns, 2f);

        PlayerStats.Money -= this.turretSelected.cost;
        Debug.Log("$" + PlayerStats.Money + " left");

        Shop.deselectTurret();
    }


}
