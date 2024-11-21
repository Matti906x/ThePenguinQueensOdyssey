using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinPickUp : MonoBehaviour
{
    [SerializeField] AudioClip coinPickUpSFX;
    [SerializeField] float volume = 1f;
    //[SerializeField] int score = 100;

    [SerializeField] TextMeshProUGUI scoreText;

    //ScoreKeeper scoreKeeper;

    bool wasCollected = false;

    void Awake()
    {
        //scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    
    //void OnTriggerEnter2D(Collider2D other) 
    //{
    //    if (other.tag == "Player" && !wasCollected)
    //    {
    //        wasCollected = true;
            //AddToScore(pointsForCoinPickup);
            //scoreKeeper.ModifyScore(score);
            //FindObjectOfType<ScoreKeeper>().ModifyScore(score);
   //         AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position, volume);
    //        Destroy(gameObject);
    //    }
    //}

    //void AddToScore(int pointsToAdd)
    //{
        //score += pointsToAdd;
        //scoreText.text = score.ToString();
    //}
}
