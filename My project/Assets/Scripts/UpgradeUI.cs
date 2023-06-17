using UnityEngine.UI;

public class UpgradeUI : NodeUI
{
    public Button upgradeButton;

    private void OnEnable()
    {
        upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
        sellPrice.text = "$" + target.turretBlueprint.sellAmount();
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
        
        if (!turret.isUpgraded)
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
