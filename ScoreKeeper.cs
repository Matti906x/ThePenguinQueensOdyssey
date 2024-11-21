using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score;

    static ScoreKeeper instance;

    void Awake()
    {
        ManageSigleton();
    }

    void ManageSigleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    
    public int GetScore()
    {
        return score;
    }

    public void ModifyScore(int value)
    {
        score += value;
        
        //to clamp the value so that it doen't go below 0 - what to clamp, min value, max value
        Mathf.Clamp(score, 0, int.MaxValue);
        Debug.Log(score);
    }

    public void ResetScore()
    {
        score = 0;
    }
}
