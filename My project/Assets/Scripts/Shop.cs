using UnityEngine;
using TMPro;
public class Shop : MonoBehaviour
{
    private BuildManager builder;
    public bool selected; // Might be redundant since there's turretSelected in builder
    public TextMeshProUGUI cannonCost;

    [Header("Turret types")]
    public TurretBlueprint cannonPrefab;

    void Start()
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
