using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ObjectChangeEventStream;

public class Node : MonoBehaviour
{
    private BuildManager builder;
    private Color onHover;
    public Color notEnoughMoneyColor;
    private Renderer rend;
    private Color STARTCOLOR;
    private Vector3 positionOffset;
    private bool nodeOccupied;

    [Header("Do not touch")]
    public GameObject turret; // is there already a turret here?
    

    void Start()
    {
        builder = BuildManager.Builder;
        rend = GetComponent<Renderer>();
        STARTCOLOR = rend.material.color;
        onHover.r = STARTCOLOR.r + 0.1f;
        onHover.g = STARTCOLOR.g + 0.1f;
        onHover.b = STARTCOLOR.b + 0.1f;
        nodeOccupied = false;
    }

    void OnMouseEnter()
    {
        if (!builder.canBuild) { return; } // Nothing is selected
        if (nodeOccupied) { return; } // Something is built
        if (builder.hasMoney)
        {
            rend.material.color = onHover;
        } else
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
        if (!builder.canBuild) { return; } // Nothing is selected
        if (nodeOccupied) { return; } // Something is built
        
        builder.BuildTurret(this);
        nodeOccupied = true;

        builder.deselectTurret();
    }

    public Vector3 PositionToBuild()
    {
        return transform.position + positionOffset;
    }
}
