using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject UI;
    private Node target;
    public Button upgradeButton;

    public void SetTarget(Node target)
    {
        this.target = target;

        if (!target.isUpgraded)
        {
            // Display the cost of upgrade here
            upgradeButton.interactable = true;
        } else
        {
            upgradeButton.interactable = false;
        }
        UI.SetActive(true);
    }

    public void Hide()
    {
        UI.SetActive(false);
        
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
    }
}
