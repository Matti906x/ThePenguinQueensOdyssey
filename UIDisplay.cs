using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] public int playerLives = 3;
    [SerializeField] public Image[] ankhs;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Update()
    {
        scoreText.text = scoreKeeper.GetScore().ToString("00000");
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            FindObjectOfType<GameSession>().ResetGameSession();
            SceneManager.LoadScene(5);
        }
    }

    public void TakeLife()
    {
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        LivesVisual();
    }

    public void LivesVisual()
    {
        for (int i = 0; i < ankhs.Length; i++)
        {
            if (i < playerLives)
            {
                ankhs[i].enabled = true;
            }
            else
            {
                ankhs[i].enabled = false;
            }
        }
    }
}
