using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowIndicators : MonoBehaviour
{
    public Canvas arrowCanvas;
    private Transform _position1;
    private Transform _position2;
    
    [SerializeField] private bool isStart;
    private float _moveSpeed = 1;

    private void Start()
    {
        _position1 = transform;
    }

    private void OnEnable()
    {
        WaveSpawner.startNextWave += disappear;
        WaveSpawner.AllEnemiesDefeated -= appear;
    }

    private void OnDisable()
    {
        WaveSpawner.AllEnemiesDefeated += appear;
        WaveSpawner.startNextWave -= disappear;
    }

    private void Update()
    {
    }

    // IEnumerator PointTowardsWaypoint()
    // {
    //     var index = 0;
    //     if (!isStart)
    //     {
    //         index = Waypoints.points.Length - 1;
    //     }
    //     // make the arrows move forward
    //     Vector3 direction = Waypoints.points[index].transform.position - transform.position;
    //     transform.Translate(direction.normalized * _moveSpeed);
    //     yield return new WaitForSeconds(0.1f);
    //     // make the arrows move backwards
    //     transform.Translate(-direction.normalized * _moveSpeed);
    // }

    void disappear(float x)
    {
        gameObject.SetActive(false);
    }

    void appear()
    {
        gameObject.SetActive(true);
    }
}
