using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurretProjectile : MonoBehaviour
{
    private protected Transform target;
    private float speed = 70f;
    public GameObject hitEffect;
    internal float damage;

    // Start is called before the first frame update
    public void Seek(Transform _target, float damageToDeal)
    {
        target = _target;
        damage = damageToDeal;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = Time.deltaTime * speed;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.rotation = Quaternion.Euler(target.transform.position);
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        //Stransform.LookAt(target);
    }

    public abstract void HitTarget();

}