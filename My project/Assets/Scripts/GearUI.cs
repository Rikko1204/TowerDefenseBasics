using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearUI : NodeUI
{
    public Button gearButton;

    [Header("Gear Type")]
    public Gear gearOne;

    
    public override void SetTarget(Node target)
    {
        this.target = target;
        this.turret = target.turretOnNode.GetComponent<Turret>();

        IsEquipped();
        UI.SetActive(true);
    }
    
    void IsEquipped()
    {
        
        if (turret.isEquipped)
        {
            gearButton.interactable = false;
        } else
        {
            gearButton.interactable = true;
        }
        
    }

    public void EquipGearOne()
    {
        base.target.EquipGear(gearOne);
    }
}
