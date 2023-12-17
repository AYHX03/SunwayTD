using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject plots;
    [SerializeField] GameObject pauseButton;
    [SerializeField] Sprite pausedSprite;
    [SerializeField] Sprite resumedSprite;

    public static bool gameIsPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }
    }

    public void Home()
    {
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        pauseButton.GetComponent<Image>().sprite = pausedSprite;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        //plots.SetActive(false);
    }

    public void Resume()
    {
        pauseButton.GetComponent<Image>().sprite = resumedSprite;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        //plots.SetActive(true);
    }



    // See if we need restart function
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
