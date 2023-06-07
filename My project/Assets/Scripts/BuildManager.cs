using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [Header("Unity setup")]
    public static BuildManager Builder;
    public Shop Shop;
    public NodeUI nodeUI;
    public TurretBlueprint turretSelected;
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
        turretSelected = null;
    }


    // Either shop turret or node can selected at a time only
    // Prepare to build turret
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretSelected = turret;
        nodeSelected = null;

        nodeUI.Hide();
    }

    // Either shop turret or node can selected at a time only
    // Prepare for upgrade
    public void SelectNode(Node node)
    {
        // Shop is selected, do not select node
        if (turretSelected != null)
        {
            return;
        }
        // Node is selected again so deselect it
        if (nodeSelected == node)
        {
            DeselectNode();
            return;
        }

        nodeSelected = node;
        turretSelected = null;

        // Provide information to UI about the node and the turret on it
        nodeUI.SetTarget(node, node.turretOnNode);
    }

    public void DeselectNode()
    {
        nodeSelected = null;
        nodeUI.Hide();
    }
}
