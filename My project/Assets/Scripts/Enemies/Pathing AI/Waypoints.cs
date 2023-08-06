// using System.Collections;
using System.Collections.Generic;

using System;
using UnityEngine;

public class Waypoints : MonoBehaviour
{

    public static List<Transform[]> points;
    // Update is called once per frame
    void Awake()
    {
        points = new List<Transform[]>(transform.childCount);
        // Outer Loop will get the parents
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            points.Add(new Transform[child.childCount]);
            // Inner Loop will insert the item into the transforms
            for (int j = 0; j < child.childCount; j++)
            {
                // bug: exceeds array boundaries somehow, idk why points[0] is out of index.
                // Debug.Log("The Length of the points array is: " + points.Count);
                points[i][j] = child.GetChild(j);
            }
        }
    }
}
