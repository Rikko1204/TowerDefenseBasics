using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver = false;
    public GameObject gameOverUI;
    private BuildManager _buildManager;
    private void Start()
    {
        _buildManager = BuildManager.Builder;
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
