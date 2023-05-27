using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver = false;
    public GameObject gameOverUI;
 
    private void Start()
    {
        GameIsOver = false;
    }

    public void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    void Update()
    {
        if (GameIsOver)
        {
            return;
        }

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }
}
