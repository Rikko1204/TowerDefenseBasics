using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeManager : MonoBehaviour
{
    public static RangeManager instance;
    private int segments = 50;
    private Vector3 offset = new Vector3(0, 1, 0);
    public LineRenderer line;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();

        line.positionCount = segments + 1;
        line.useWorldSpace = false;
        gameObject.SetActive(false);
        transform.Rotate(90, 0, 0);
    }

    void CreatePoints(float xradius, float yradius)
    {
        float x;
        float y;
        float z;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * yradius;

            line.SetPosition(i, new Vector3(x, y, 0));

            angle += (360f / segments);
        }
    }

    public void ShowRange(int range, Transform location)
    {
        gameObject.SetActive(true);
        gameObject.transform.position = location.position + offset;

        CreatePoints(range, range);
    }

    public void HideRange()
    {
        gameObject.SetActive(false);
        CreatePoints(0, 0);
    }
}
