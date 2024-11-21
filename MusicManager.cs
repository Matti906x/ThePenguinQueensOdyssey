using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SceneVolumeSettings
{
    public int sceneIndex;
    [Range(0.0f, 1.0f)]
    public float volume = 1.0f;
}

public class MusicManager : MonoBehaviour
{
    public AudioClip[] sceneMusic; // Array to hold music clips for different scenes
    private AudioSource audioSource;
    private int currentSceneIndex;

    public List<SceneVolumeSettings> volumeSettings = new List<SceneVolumeSettings>(); // List to hold scene-specific volume settings

    void Awake()
    {
        int numMusicManagers = FindObjectsOfType<MusicManager>().Length;
        if (numMusicManagers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Check if the volumeSettings list is not empty before setting the volume
        if (volumeSettings.Count > 0)
        {
            audioSource.volume = volumeSettings[0].volume;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;

        // Check if the first scene is already loaded
        Scene firstScene = SceneManager.GetSceneAt(0);
        if (firstScene.isLoaded)
        {
            currentSceneIndex = firstScene.buildIndex;
            OnSceneLoaded(firstScene, LoadSceneMode.Single);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentSceneIndex = scene.buildIndex;
        PlaySceneMusic(currentSceneIndex);
        ApplyVolumeSettings(currentSceneIndex);
    }

    void PlaySceneMusic(int sceneIndex)
    {
        if (sceneIndex >= 0 && sceneIndex < sceneMusic.Length && sceneMusic[sceneIndex] != null)
        {
            if (!audioSource.isPlaying || audioSource.clip != sceneMusic[sceneIndex])
            {
                audioSource.clip = sceneMusic[sceneIndex];
                audioSource.Play();
            }
        }
    }

    void ApplyVolumeSettings(int sceneIndex)
    {
        foreach (var setting in volumeSettings)
        {
            if (setting.sceneIndex == sceneIndex)
            {
                audioSource.volume = setting.volume;
                return;
            }
        }
        // If no specific volume setting for the scene, use default volume
        audioSource.volume = 1.0f;
    }
}