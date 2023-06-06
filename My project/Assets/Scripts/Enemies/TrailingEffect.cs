/*
 * This class is made to allow particle effects instantiated during runtime
 * to follow an Enemy
 */

using System;
using UnityEngine;

public class TrailingEffect : MonoBehaviour
{
    private Transform _target;
    private Vector3 _offset;

    public void Follow(Transform target, Vector3 offset)
    {
        _target = target;
        _offset = offset;
    }

    private void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = _target.position - transform.position + _offset;
        transform.Translate(dir, Space.World);

    }
}