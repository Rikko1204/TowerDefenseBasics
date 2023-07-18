using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowIndicators : MonoBehaviour
{
    public Waypoints waypoints;
    public Canvas arrowCanvas;
    private Transform _position1;
    private Transform _position2;

    [SerializeField] private int location;

    private void Start()
    {
        _position1 = gameObject.transform;
        _position2 = Waypoints.points[location];
    }

    void pointTowardsWaypoint(int index)
    {
        var State = 0;
        // make the arrows move forward
        
        // make the arrows move backwards
    }
}
