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
    public static bool GameIsPaused = false;
    public GameObject gameOverUI;
    public GameObject VictoryUI;
    public GameObject PlayerUI;
    public GameObject ShopUI;
    public GameObject pauseUI;
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

    public void EndGame(bool isVictorious)
    {
        GameIsOver = true;
        
        if (isVictorious)
        {
            VictoryUI.SetActive(true);
        }
        else
        {
            // clear the screen
            var enemiesToRemove = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy in enemiesToRemove)
            {
                Destroy(enemy);
            }

            // Deselect any Towers
            _buildManager.SelectTurretToBuild(null);
            // Open the GameOverScreen
            gameOverUI.SetActive(true);
        }
    }


    public static void FastForward()
    {
        Time.timeScale = (1 / Time.timeScale) * 4;
    }
    

    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            if (!GameIsPaused)
            {
                pauseUI.SetActive(true);
            }
            else
            {
                pauseUI.SetActive(false);
            }

            GameIsPaused = !GameIsPaused;
        }
        if (GameIsOver)
        {
            return;
        }

        if (PlayerStats.Lives <= 0)
        {
            EndGame(false);
        }
    }
}
