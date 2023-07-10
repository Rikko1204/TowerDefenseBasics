using UnityEngine;
using TMPro;
public class Shop : MonoBehaviour
{
    private BuildManager builder;
    public bool selected; // Might be redundant since there's turretSelected in builder
    public TextMeshProUGUI cannonCost;
    public TextMeshProUGUI XbowCost;
    public TextMeshProUGUI mineCost;
    public TextMeshProUGUI slowTurretCost;
    public TextMeshProUGUI catapultCost;
    public TextMeshProUGUI monolithCost;

    [Header("Turret types")]
    public TurretBlueprint cannonPrefab;
    public TurretBlueprint XbowPrefab;
    public TurretBlueprint minePrefab;
    public TurretBlueprint slowTurretPrefab;
    public TurretBlueprint catapultPrefab;
    public TurretBlueprint monolithPrefab;

    void Start()
    {
        builder = BuildManager.Builder;
        this.selected = false;

        cannonCost.text = "$ " + cannonPrefab.cost;
        XbowCost.text = "$ " + XbowPrefab.cost;
        mineCost.text = "$ " + minePrefab.cost;
        slowTurretCost.text = "$ " + slowTurretPrefab.cost;
        catapultCost.text = "$ " + catapultPrefab.cost;
        monolithCost.text = "$ " + monolithPrefab.cost;
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
    public void SelectXbow()
    {
        if (!selected)
        {
            builder.SelectTurretToBuild(XbowPrefab);
            this.selected = true;
        }
        else deselectTurret();
    }
    public void SelectMine()
    {
        if (!selected)
        {
            builder.SelectTurretToBuild(minePrefab);
            this.selected = true;
        }
        else deselectTurret();
    }
    public void SelectSlowTurret()
    {
        if (!selected)
        {
            builder.SelectTurretToBuild(slowTurretPrefab);
            this.selected = true;
        }
        else deselectTurret();
    }
    public void SelectCatapult()
    {
        if (!selected)
        {
            builder.SelectTurretToBuild(catapultPrefab);
            this.selected = true;
        }
        else deselectTurret();
    }
    public void SelectMonolith()
    {
        if (!selected)
        {
            builder.SelectTurretToBuild(monolithPrefab);
            this.selected = true;
        }
        else deselectTurret();
    }
    public void deselectTurret()
    {
        builder.SelectTurretToBuild(null);
        this.selected = false;
    }
}
