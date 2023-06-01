using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    public GameObject UI;
    private Node target;

    public void SetTarget(Node target)
    {
        this.target = target;
        UI.SetActive(true);
    }

    public void Hide()
    {
        UI.SetActive(false);
        
    }
}
