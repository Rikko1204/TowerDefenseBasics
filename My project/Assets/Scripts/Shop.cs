using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;
using static UnityEditor.ObjectChangeEventStream;

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
        this.selected = false;
        cannonCost.text = "$ " + cannonPrefab.cost;

    }
    public void SelectCannon()
    {
        if (!selected)
        {
            builder.SelectTurretToBuild(cannonPrefab);
            this.selected = true;
        }
        else deselectTurret();
    }

    public void SelectMortar()
    {

    }
    public void deselectTurret()
    {
        builder.SelectTurretToBuild(null);
        this.selected = false;
    }
}
