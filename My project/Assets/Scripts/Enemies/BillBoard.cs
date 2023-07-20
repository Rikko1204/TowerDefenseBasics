using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    public Transform camera;
    private GameManager gm = GameManager._gameManager;
    
    private void Start()
    {
        camera = gm.cam;
    }

    private void LateUpdate()
    {
       transform.LookAt(transform.position + camera.forward); 
    }
}
