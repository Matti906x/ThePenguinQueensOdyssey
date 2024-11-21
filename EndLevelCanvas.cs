using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndLevelCanvas : MonoBehaviour
{
    [SerializeField] Canvas endLevelCanvas;
    string textToType = "I've been waiting for you, Neferusobek. Unfortunately, I cannot give you back your appearance and your throne. This can only be done by your tutelary deity, Sobek, the crocodile God. His temple is located in an oasis along the Nile and is protected by a very dangerous creature. I will give you the power to defeat it, but everything will depend on you. May you be successful in your journey...";
    TMP_Text subtitleTextMesh;
    [SerializeField] float textDelay = 0.05f;

    [SerializeField] Button myButton;
    [SerializeField] float levelButtonDelay = 1f;

    Rigidbody2D myRigidbody;
    
    void Start()
    {
        endLevelCanvas.GetComponent<Canvas>().enabled = false;
        myRigidbody = GetComponent<Rigidbody2D>();
        
        // Attempt to find TMP_Text component in children of endLevelCanvas
        subtitleTextMesh = endLevelCanvas.GetComponentInChildren<TMP_Text>();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if( other.tag == "EndLevel")
        {
            myRigidbody.isKinematic = true;
            FindObjectOfType<PlayerMovement>().runSpeed = 0;
            FindObjectOfType<PlayerMovement>().jumpSpeed = 0;
            endLevelCanvas.GetComponent<Canvas>().enabled = true;
            myButton.gameObject.SetActive(false);
            StartCoroutine(ShowButton());
            StartCoroutine(TypeText());
        }
    }

    IEnumerator ShowButton()
    {
        yield return new WaitForSecondsRealtime(levelButtonDelay);
        myButton.gameObject.SetActive(true);
    }

    IEnumerator TypeText()
    {
        subtitleTextMesh.text = string.Empty;

        for (int i = 0; i < textToType.Length; i++)
        {
            subtitleTextMesh.text += textToType[i];
            yield return new WaitForSeconds(textDelay);
        }

        yield return null;
    }
}
