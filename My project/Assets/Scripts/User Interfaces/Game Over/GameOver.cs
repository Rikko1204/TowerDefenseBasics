using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private AudioManager _audioManager;
    
    public TextMeshProUGUI roundsSurvived;
    // when this Panel is first enabled, it will display rounds survived.

    private void Awake()
    {
        _audioManager = AudioManager.instance;
    }
    private void OnEnable()
    {
        roundsSurvived.text = "You Reached Round: " + PlayerStats.Rounds;
        Time.timeScale = 0;
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        _audioManager.PlayNext("Battle");
    }

    public void GoToMenu()
    {
        // Debug.Log("Going To Menu");
        SceneManager.LoadScene(0);
        _audioManager.PlayNext("MainMenu");
    }
}
