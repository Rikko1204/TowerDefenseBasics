using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace User_Interfaces
{
    public class PauseMenu : MonoBehaviour
    {
        public GameObject thisScreen;
        private AudioManager _audioManager;
        // private float _originalTimeScale;


        void OnEnable()
        {
            // _originalTimeScale = Time.timeScale;
            Time.timeScale = 0;
            _audioManager = AudioManager.instance;

        }

        private void OnDisable()
        {
            // This is an intended feature for now:
            // since you wanted to pause maybe it's cos you wanted to stop n think
            Time.timeScale = 1;
            
            // USE THIS and uncomment above if you want to retain ff state instead.
            // Time.timeScale = _originalTimeScale;
        }

        public void Continue()
        {
            GameManager.GameIsPaused = false;
            thisScreen.SetActive(false);
            _audioManager.Unpause();
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
