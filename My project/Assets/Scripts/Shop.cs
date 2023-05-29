using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager builder;
    private bool _selected;

    [Header("Turret types")]
    public TurretBlueprint cannonPrefab;

    private void Start()
    {
        builder = BuildManager.Builder;
        _selected = false;
    }
    public void SelectCannon()
    {
        if (!_selected)
        {
            builder.SetTurretToBuild(cannonPrefab);
            _selected = true;
        }
        else deselect();
    }

    public void SelectMortar()
    {

    }

    public void deselect()
    {
        builder.SetTurretToBuild(null);
        _selected = false;
    }
}
