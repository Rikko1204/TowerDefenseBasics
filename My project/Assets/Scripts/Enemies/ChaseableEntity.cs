/*
 * This Script is attached to an enemy that would have to be searched for
 * (e.g. finding the closest enemy of type Healer)
 * This may be modified in the future if specific abilities can only target specific enemies.
 * Without using FindGameObjectWithTag (because that is inefficient)
 */

using System.Collections.Generic;
using UnityEngine;

public class ChaseableEntity : MonoBehaviour
{
    public static readonly HashSet<ChaseableEntity> Entities = new HashSet<ChaseableEntity>();

    private void Awake()
    {
        Entities.Add(this);
    }

    private void OnDestroy()
    {
        Entities.Remove(this);
    }
}