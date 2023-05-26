using UnityEngine;

public class CannonBall : MonoBehaviour
{
    private Transform target;
    private float speed = 40f;
    public GameObject hitEffect;

    // Start is called before the first frame update
    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) {
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
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
        GameObject hitImpact = (GameObject) Instantiate(hitEffect, target.position, target.rotation);
        Destroy(hitImpact, 2f);

        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
