using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{    
    void Awake() 
    {
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (numMusicPlayers > 1 && currentSceneIndex != 2)
        {
            Destroy(gameObject);
        }
        else if (currentSceneIndex == 2)
        {
            DontDestroyOnLoad(gameObject);
        }     
    }
}
