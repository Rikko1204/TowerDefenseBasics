using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    public string message;

    private void OnMouseEnter()
    {
        TooltipManager.instance.ShowTooltip(message);
    }

    private void OnMouseExit()
    {
        TooltipManager.instance.HideTooltip();
    }

    // The methods below are for non-game objects like buttons
    public void OnHover(Transform position)
    {
        TooltipManager.instance.ObjectToHoverOver(position);
        TooltipManager.instance.ShowTooltip(message);
    }

    public void OnHoverExit()
    {
        TooltipManager.instance.HideTooltip();
    }
}
