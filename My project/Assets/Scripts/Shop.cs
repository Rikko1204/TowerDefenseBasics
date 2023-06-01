using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    private BuildManager builder;
    public bool selected;
    public TextMeshProUGUI cannonCost;

    [Header("Turret types")]
    public TurretBlueprint cannonPrefab;

    private void Start()
    {
        builder = BuildManager.Builder;
        selected = false;
        cannonCost.text = "$ " + cannonPrefab.cost;
    }
    public void SelectCannon()
    {
        if (!selected)
        {
            builder.SetTurretToBuild(cannonPrefab);
            selected = true;
        }
        else builder.deselectTurret();
    }

    public void SelectMortar()
    {

    }
}
