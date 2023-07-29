using UnityEngine;
using TMPro;
public class Shop : MonoBehaviour
{
    
    [System.Serializable]
    public class ShopItem
    {
        public TextMeshProUGUI costText;
        public TurretBlueprint prefab;
    }

    private BuildManager builder;
    public bool selected; // Might be redundant since there's turretSelected in builder

    [Header("Turret types")]
    public ShopItem[] shopItems;
    void Start()
    {
        builder = BuildManager.Builder;
        this.selected = false;
        InvokeRepeating("CanAfford", 0f, 0.2f);

        foreach(ShopItem item in shopItems) 
        {
            item.costText.text = "$ " + item.prefab.towerLevels[0].cost;
        }
    }
    public void SelectCannon()
    {
        if (!selected)
        {
            builder.SelectTurretToBuild(shopItems[0].prefab);
            Node.TypeOfTurret = 0;
            this.selected = true;
        }
        else deselectTurret();
    }
    public void SelectXbow()
    {
        if (!selected)
        {
            builder.SelectTurretToBuild(shopItems[1].prefab);
            this.selected = true;
        }
        else deselectTurret();
    }
    public void SelectMine()
    {
        if (!selected)
        {
            builder.SelectTurretToBuild(shopItems[2].prefab);
            this.selected = true;
        }
        else deselectTurret();
    }
    public void SelectSlowTurret()
    {
        if (!selected)
        {
            builder.SelectTurretToBuild(shopItems[3].prefab);
            this.selected = true;
        }
        else deselectTurret();
    }
    public void SelectCatapult()
    {
        if (!selected)
        {
            builder.SelectTurretToBuild(shopItems[4].prefab);
            this.selected = true;
        }
        else deselectTurret();
    }
    public void SelectMonolith()
    {
        if (!selected)
        {
            builder.SelectTurretToBuild(shopItems[5].prefab);
            this.selected = true;
        }
        else deselectTurret();
    }
    public void deselectTurret()
    {
        builder.SelectTurretToBuild(null);
        this.selected = false;
    }

    public void CanAfford()
    {
        foreach(ShopItem item in shopItems)
        {
            if (PlayerStats.Money < item.prefab.towerLevels[0].cost)
            {
                item.costText.color = Color.red;
            }
            else
            {
                item.costText.color = Color.white;
            }
        }
    }
}
