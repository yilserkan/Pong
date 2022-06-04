using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    [SerializeField] private ScoreHandler scoreHandler = null;
    [SerializeField] private MainMenu mainMenu = null;

    public void RestartGame()
    {
        scoreHandler.ResetScore();
        mainMenu.ResetPosition();
        Time.timeScale = 1;
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
