using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace User_Interfaces
{
    public class PauseMenu : MonoBehaviour
    {
        public GameObject thisScreen;
        // Start is called before the first frame update
        void OnEnable()
        {
            Time.timeScale = 0;
        }

        private void OnDisable()
        {
            Time.timeScale = 1;
        }

        public void Continue()
        {
            GameManager.GameIsPaused = false;
            thisScreen.SetActive(false);
        }

        public void Retry()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }
    
        public void GoToMenu()
        {
            // Debug.Log("Going To Menu");
            SceneManager.LoadScene(0);
        }
    }
}
