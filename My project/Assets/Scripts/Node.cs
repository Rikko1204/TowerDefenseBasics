using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    public Color onHover;
    private Renderer rend;
    private Color STARTCOLOR;

    private Turret _turret;
    void Start()
    {
        rend = GetComponent<Renderer>();
        STARTCOLOR = rend.material.color;
        onHover.r = STARTCOLOR.r + 0.1f;
        onHover.g = STARTCOLOR.g + 0.1f;
        onHover.b = STARTCOLOR.b + 0.1f;
    }

    void OnMouseEnter()
    {
       //change colour 
       rend.material.color = onHover;
    }

    void OnMouseExit()
    {
        rend.material.color = STARTCOLOR;
    }

    private void OnMouseDown()
    {
        if (_turret != null)
        {
            // something's already here
            return;
        }
        
    }
}
