using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager instance;
    public TextMeshProUGUI text;
    private Transform hoverOverObject;
    private Vector3 offset;
    private string message;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        } 
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
        offset = new Vector3(90, 0, 0);
    }

    private void Update()
    {
        transform.position = hoverOverObject.position + offset;
    }
    public void ShowTooltip(string message)
    {
        gameObject.SetActive(true);
        text.text = message;
        this.message = message;
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
        text.text = "";
    }

    public void ObjectToHoverOver(Transform transform)
    {
        hoverOverObject = transform;
    }
}
