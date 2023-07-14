using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlmanacMenu : MonoBehaviour
{
    public GameObject towersAlmanac;
    public GameObject enemiesAlmanac;

    public void GoToTowersAlmanac()
    {
        gameObject.SetActive(false);
        towersAlmanac.SetActive(true);
        CanvasStack.StackOfCanvas.Push(gameObject);
    }

    public void GoToEnemiesAlmanac()
    {
        gameObject.SetActive(false);
        enemiesAlmanac.SetActive(true);
        CanvasStack.StackOfCanvas.Push(gameObject);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
