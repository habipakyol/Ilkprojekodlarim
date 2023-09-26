using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class denemecanvas : MonoBehaviour
{
    public GameObject pauseCanvas;
    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f; // Oyun zamanýný duraklat
        isPaused = true;
        pauseCanvas.SetActive(true);
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f; // Oyun zamanýný normale çevir
        isPaused = false;
        pauseCanvas.SetActive(false);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
