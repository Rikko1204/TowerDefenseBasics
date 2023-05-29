using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI roundsSurvived;
    // when this Panel is first enabled, it will display rounds survived.
    private void OnEnable()
    {
        roundsSurvived.text = "You Reached Round: " + PlayerStats.Rounds;
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu()
    {
        Debug.Log("Going To Menu");
        //SceneManager.LoadScene(0);
    }
}
