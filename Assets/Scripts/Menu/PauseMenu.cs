using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
    }

    public void OnPauseKeyPress() {
        if (GameIsPaused)
        {
            Resume();
        } else
        {
            Pause();
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void OnResumeButton()
    {
        Resume();
    }

    public void OnMainMenuButton()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void OnQuitButton()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void Restart() {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene);
    }
}
