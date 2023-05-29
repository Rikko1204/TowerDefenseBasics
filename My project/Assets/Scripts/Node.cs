using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private BuildManager builder;
    public Color onHover;
    private Renderer rend;
    private Color STARTCOLOR;
    public Vector3 positionOffset;


    public GameObject turret; // is there already a turret here?
    private bool nodeOccupied;


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
        rend.material.color = onHover;
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
    }

    public Vector3 PositionToBuild()
    {
        return transform.position + positionOffset;
    }
}
