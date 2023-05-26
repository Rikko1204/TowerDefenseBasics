using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager builder;

    private void Start()
    {
        builder = BuildManager.builder;
    }
    public void SelectCannon()
    {
        builder.SetTurretToBuild(builder.cannonPrefab);
    }

    public void SelectMortar()
    {

    }
}
