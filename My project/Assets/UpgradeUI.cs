using UnityEngine.UI;

public class UpgradeUI : NodeUI
{
    public Button upgradeButton;

    private void OnEnable()
    {
        upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
        sellPrice.text = "$" + target.turretBlueprint.sellAmount(target.IsUpgraded);
    }
    
    public override void SetTarget(Node target, Turret targetTurret)
    {
        this.target = target;
        this.targetTurret = targetTurret;

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
        if (!targetTurret.isUpgraded)
        {
            // Display the cost of upgrade here
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeButton.interactable = false;
        }
    }
}
