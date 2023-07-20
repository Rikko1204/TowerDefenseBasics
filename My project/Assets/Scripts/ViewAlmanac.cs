using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewAlmanac : MonoBehaviour
{
    public void Back()
    {
        gameObject.SetActive(false);
        GameObject almanacMenu = CanvasStack.StackOfCanvas.Pop();
        almanacMenu.SetActive(true);
    }
}
