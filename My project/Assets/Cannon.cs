using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Transform target;
    public float range = 5f;
    public string enemyTag = "Enemy";
    public float turnSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = int.MaxValue;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            Vector3 dir = enemy.transform.position - transform.position;
            if (dir.magnitude < shortestDistance)
            {
                shortestDistance = dir.magnitude;
                nearestEnemy = enemy;
            }

            if (nearestEnemy != null && shortestDistance <= range)
            {
                target = nearestEnemy.transform;
            } else
            {
                target = null;
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (target == null) { return; }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
