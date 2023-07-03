using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SellUI : MonoBehaviour
{
    public GameObject UI;
    public TextMeshProUGUI sellPrice;
    internal Node target;
    internal Turret turret;
    private void OnEnable()
    {       
        sellPrice.text = "$" + target.turretBlueprint.sellAmount();
    }

    public void SetTarget(Node target)
    {
        this.target = target;
        this.turret = target.turretOnNode.GetComponent<Turret>();
        UI.SetActive(true);
    }

    public void Sell()
    {
        target.SellTurret();
    }

    public void Hide()
    {
        UI.SetActive(false);
    }
}
