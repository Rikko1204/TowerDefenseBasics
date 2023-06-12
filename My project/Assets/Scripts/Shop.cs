using UnityEngine;
using TMPro;
public class Shop : MonoBehaviour
{
    private BuildManager builder;
    public bool selected; // Might be redundant since there's turretSelected in builder
    public TextMeshProUGUI cannonCost;
    public TextMeshProUGUI XbowCost;

    [Header("Turret types")]
    public TurretBlueprint cannonPrefab;
    public TurretBlueprint XbowPrefab;

    void Start()
    {
        builder = BuildManager.Builder;
        this.selected = false;
        cannonCost.text = "$ " + cannonPrefab.cost;
        XbowCost.text = "$ " + XbowPrefab.cost;

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
    public void deselectTurret()
    {
        builder.SelectTurretToBuild(null);
        this.selected = false;
    }
}
