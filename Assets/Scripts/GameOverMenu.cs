using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] GameObject gameOverMenu;

    public static bool isGameOver = false;
    public CloudSave cloudSave;

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) 
        {
            GameOver();
        }
    }

    void GameOver() 
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
        cloudSave.SaveData("Science", 2);
        isGameOver = false;

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        isGameOver = false;
    }

    public void Home()
    {
        Time.timeScale = 1f;
    }
}
