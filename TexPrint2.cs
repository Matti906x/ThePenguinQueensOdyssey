using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TexPrint2 : MonoBehaviour
{
    string textToType = "Finally, the day has arrived! Neferusobek has regained her appearance and Sobek, together with Horus and Osiris, have defeated the evil Seth and overthrown the usurper Ugaf! This opens up a bright future for Egypt under the rule of the great queen (at least until the next plot...). Glory to the Queen of Egypt!";
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
