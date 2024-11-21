using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndLevelCanvas2 : MonoBehaviour
{
    [SerializeField] Canvas endLevelCanvas;
    string textToType = "Neferusobek, my child, I am aware of your bad luck, but the fact that you have arrived here means that you are strong, smart and proud. I will give you back your original appearance and call the other Gods to fight together against Seth and the usurper Ugarif. I'm proud of you, Queen of Egypt!";
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
        if( other.tag == "EndLevel2")
        {
            myRigidbody.isKinematic = true;
            FindObjectOfType<PlayerMovement>().runSpeed = 0;
            FindObjectOfType<PlayerMovement>().jumpSpeed = 0;
            endLevelCanvas.GetComponent<Canvas>().enabled = true;
            StartCoroutine(TypeText());
            myButton.gameObject.SetActive(false);
            StartCoroutine(ShowButton());
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
