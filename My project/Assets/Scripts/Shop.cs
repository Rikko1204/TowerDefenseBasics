using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager builder;
    private bool _selected;

    private void Start()
    {
        builder = BuildManager.builder;
        _selected = false;
    }
    public void SelectCannon()
    {
        if (!_selected)
        {
            builder.SetTurretToBuild(builder.cannonPrefab);
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
