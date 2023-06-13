using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearUI : NodeUI
{
    public Button gearButton;

    [Header("Gear Type")]
    public Gear gearOne;
    //public Gear gearTwo;

    
    public override void SetTarget(Node target, Turret targetTurret)
    {
        this.target = target;
        this.targetTurret = targetTurret;

        IsEquipped();
        UI.SetActive(true);
    }
    
    void IsEquipped()
    {
        if (targetTurret.isEquipped)
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
