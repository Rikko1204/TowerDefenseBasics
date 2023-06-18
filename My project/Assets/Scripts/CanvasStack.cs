using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasStack : MonoBehaviour
{
    public static Stack<GameObject> StackOfCanvas = new Stack<GameObject>();

    public void AddCanvasToStack()
    {
        StackOfCanvas.Push(gameObject);
    }
}
