using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preview : MonoBehaviour
{
    // Start is called before the first frame update
    public static Transform Available;

    public static Transform Unavailable;

    void Awake()
    {
      Available = transform.GetChild(0);
      Unavailable = transform.GetChild(1);
    }

}
