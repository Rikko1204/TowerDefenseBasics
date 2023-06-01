using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /*
     * GameManager is a special name reserved for Scripts.
     * It allows certain functions such as using a UI for a GameObject while the normal script doesn't
     */
    public static bool GameIsOver = false;
    public GameObject gameOverUI;
    public GameObject PlayerUI;
    public GameObject ShopUI;
    private BuildManager _buildManager;
    public static GameManager _gameManager;

    private void Awake()
    {
        if (_gameManager != null)
        {
            return;
        }

        _gameManager = this;
        _buildManager = BuildManager.Builder;
    }

    private void Start()
    {
        GameIsOver = false;
    }

    public void EndGame()
    {
        GameIsOver = true;
        
        // clear the screen
        var enemiesToRemove = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemiesToRemove)
        {
            Destroy(enemy);
        }

        // Deselect any Towers
        _buildManager.SetTurretToBuild(null);
        // Open the GameOverScreen
        gameOverUI.SetActive(true);
    }

    public static void Restart()
    {
        GameIsOver = false;
    }

    public void SetupUI()
    {
        PlayerUI.SetActive(true);
        ShopUI.SetActive(true);
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
