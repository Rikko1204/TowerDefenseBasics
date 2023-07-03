using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class NodeUI : MonoBehaviour
{
    public GameObject UI;
    public TextMeshProUGUI upgradeCost;
    public TextMeshProUGUI sellPrice;
    internal Node target;
    internal Turret turret;
    //internal Turret targetTurret;

    public abstract void SetTarget(Node target);



    public void Hide()
    {
        UI.SetActive(false);
    }

}
