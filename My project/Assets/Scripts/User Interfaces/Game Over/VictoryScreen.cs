using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    public TextMeshProUGUI stars;
    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = AudioManager.instance;
    }
    private void OnEnable()
    {
        int livesRemaining = PlayerStats.Lives;
        int stars = ConvertToStars(livesRemaining);

        this.stars.text = "You've completed this level with " + stars + " stars!";
    }

    public int ConvertToStars(int starCount)
    {
        switch (starCount)
        {
            case >= 18:
                return 3;
            case >= 12:
                return 2;
            default:
                return 1;
        }
    }

    public void GoToMenu()
    {
        // Debug.Log("Going To Menu");
        SceneManager.LoadScene(0);
        _audioManager.PlayNext("MainMenu");
    }
    
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        _audioManager.PlayNext("Battle");
    }
}