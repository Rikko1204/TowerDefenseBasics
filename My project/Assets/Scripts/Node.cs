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


    private GameObject _turret; // is there already a turret here?


    void Start()
    {
        builder = BuildManager.builder;
        rend = GetComponent<Renderer>();
        STARTCOLOR = rend.material.color;
        onHover.r = STARTCOLOR.r + 0.1f;
        onHover.g = STARTCOLOR.g + 0.1f;
        onHover.b = STARTCOLOR.b + 0.1f;
    }

    void OnMouseEnter()
    {
        if (builder.GetTurretToBuild() == null) { return; } // Nothing is selected
        rend.material.color = onHover;
    }

    void OnMouseExit()
    {
        rend.material.color = STARTCOLOR;
    }

    private void OnMouseDown()
    {
        if (builder.GetTurretToBuild() == null) { return; } // Nothing is selected
        if (_turret != null) { return; } // Something is built
        
        GameObject turretToBuild = BuildManager.builder.GetTurretToBuild();


        _turret = Instantiate(turretToBuild, 
            transform.position + positionOffset,
            transform.rotation);
    }
}
