using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private BuildManager builder;
    private Color onHover;
    public Color notEnoughMoneyColor;
    private Renderer rend;
    private Color STARTCOLOR;
    private Vector3 positionOffset;
    internal bool nodeOccupied; // Might be redundant since there's turretOnNode

    [Header("Do not touch")]
    internal GameObject turretOnNode; // Is there already a turret here?
    internal TurretBlueprint turretBlueprint;
    internal bool isUpgraded;
    

    void Start()
    {
        builder = BuildManager.Builder;
        rend = GetComponent<Renderer>();
        STARTCOLOR = rend.material.color;
        onHover.r = STARTCOLOR.r + 0.1f;
        onHover.g = STARTCOLOR.g + 0.1f;
        onHover.b = STARTCOLOR.b + 0.1f;
        nodeOccupied = false;
        isUpgraded = false;
    }

    void OnMouseEnter()
    {
        // Selecting a node when shop is not selected should highlight the node
        if (nodeOccupied && !builder.canBuild)
        {
            rend.material.color = onHover;
        }

        // If shop is not selected, don't highlight node
        if (!builder.canBuild)  
        {
            return;
        }

        // If conditions met below, ready to build turret. Else do nothing.
        if (builder.hasMoney && builder.canBuild && !nodeOccupied)
        {
            rend.material.color = onHover;
        } else if (!builder.hasMoney)
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = STARTCOLOR;
    }

    private void OnMouseDown()
    {
        // If turret is built, select node and bring up node UI
        if (nodeOccupied) 
        {
            builder.SelectNode(this);
            return; 
        }

        // If shop turret not selected, return
        if (!builder.canBuild) { return; } 
        
        this.BuildTurret(builder.turretSelected);
    }

    void BuildTurret(TurretBlueprint turretPrefab)
    {
        if (PlayerStats.Money < turretPrefab.cost)
        {
            Debug.Log("Not enough money");
            builder.Shop.deselectTurret();
            return;
        }

        GameObject turretToBuildIns = (GameObject) Instantiate(turretPrefab.prefab, this.PositionToBuild(), Quaternion.identity);
        GameObject buildEffectIns = (GameObject) Instantiate(builder.buildEffect, this.PositionToBuild(), Quaternion.identity);

        this.turretBlueprint = turretPrefab;
        this.turretOnNode = turretToBuildIns;
        this.nodeOccupied = true;
        Destroy(buildEffectIns, 2f);

        PlayerStats.Money -= turretPrefab.cost;
        Debug.Log("$" + PlayerStats.Money + " left");

        builder.Shop.deselectTurret();
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money");
            builder.Shop.deselectTurret();
            return;
        }

        Destroy(turretOnNode);

        GameObject turretToBuildIns = (GameObject) Instantiate(turretBlueprint.upgradedPrefab, this.PositionToBuild(), Quaternion.identity);
        GameObject buildEffectIns = (GameObject) Instantiate(builder.buildEffect, this.PositionToBuild(), Quaternion.identity);

        this.turretOnNode = turretToBuildIns;

        Destroy(buildEffectIns, 2f);

        PlayerStats.Money -= turretBlueprint.upgradeCost;
        Debug.Log("$" + PlayerStats.Money + " left. Turret upgraded!");

        builder.Shop.deselectTurret();
        this.isUpgraded = true;
    }
    public Vector3 PositionToBuild()
    {
        return transform.position + positionOffset;
    }
}
