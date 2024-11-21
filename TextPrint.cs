using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextPrint : MonoBehaviour
{
    string textToType = "Upon the death of Pharaoh Amenemhat IV, the wise and beautiful Neferusobek is crowned Queen of Egypt, becoming the first female pharaoh in over 1000 years. But not everyone is happy, and the general Ugaf makes a pact with the evil God Seth to obtain the throne. He casts a curse to tranform her into a very unique animal, which no one had ever seen before in the land of the Nile... a penguin! But all is not lost, Neferusobek is not the type to give up easily. She thus begins a journey to obtain the help of benevolent deities and to regain her rightful throne... and even her appearance!";
    TMP_Text subtitleTextMesh;
    [SerializeField] float timeToWait = 0.05f;
    
    void Awake()
    {
        subtitleTextMesh = GetComponent<TMP_Text>();
    }
    
    void Start()
    {
            StartCoroutine(TypeTextCO());
    }

    IEnumerator TypeTextCO()
    {
        subtitleTextMesh.text = string.Empty;

        for (int i = 0; i < textToType.Length; i++)
        {
            subtitleTextMesh.text += textToType[i];
            yield return new WaitForSeconds(timeToWait);
        }

        yield return null;
    }
}
