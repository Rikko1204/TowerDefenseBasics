using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : NodeUI
{
    public Button upgradeButton;

    private void OnEnable()
    {
        if (target.nextUpgradeLevel <= 4)
        {
            upgradeCost.text = "$" + target.turretBlueprint.towerLevels[target.nextUpgradeLevel - 1].cost;
        } 
        else
        {
            upgradeCost.text = "";
        }
        
        sellPrice.text = "$" + target.turretBlueprint.sellAmount(target.nextUpgradeLevel - 1);
    }

    private void Start()
    {
        InvokeRepeating("CanAfford", 0f, 0.5f);
    }

    public override void SetTarget(Node target)
    {
        this.target = target;
        this.turret = target.turretOnNode.GetComponent<Turret>();
        IsUpgradeable();
        UI.SetActive(true);
    }
    
    public void Upgrade()
    {
        base.target.UpgradeTurret();
    }

    public void Sell()
    {
        base.target.SellTurret();
    }

    void IsUpgradeable()
    {
        if (target.nextUpgradeLevel <= 4)
        {
            // Display the cost of upgrade here
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeButton.interactable = false;
        }
    }

    void CanAfford()
    {
        if (PlayerStats.Money < target.turretBlueprint.towerLevels[target.nextUpgradeLevel - 1].cost)
        {
            upgradeCost.color = Color.red;
        } 
        else
        {
            upgradeCost.color = Color.white;
        }
    }
}
