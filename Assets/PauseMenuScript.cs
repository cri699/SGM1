using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour {
    public GameManagerScript gm;
    public static bool GameIsPause = false;
    public GameObject pauseMenuUi;
    // Use this for initialization
    void Start()
    {
        Resume();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

   public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }
    void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0;
        GameIsPause = true;
    }

    
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void RestartGame()
    {
        gm.RestartGame();
    }
}
