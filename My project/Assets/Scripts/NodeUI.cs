using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class NodeUI : MonoBehaviour
{
    public GameObject UI;
    internal Node target;
    internal Turret targetTurret;

    public abstract void SetTarget(Node target, Turret targetTurret);



    public void Hide()
    {
        UI.SetActive(false);
        
    }

}
