using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{    
    public void LoadMainManu()
    {
        FindObjectOfType<ScoreKeeper>().ResetScore();
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
    }

    public void LoadIntro()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadNextLevel()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(3);
    }
    
    public void LoadWin()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        FindObjectOfType<GameSession>().ResetGameSession();
        SceneManager.LoadScene(4);
    }

    public void LoadGameOver()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(5);
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene(6);
    }

    public void QuitGame()
    {
        Debug.Log("You quitted");
        Application.Quit();
    }
}
