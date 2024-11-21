using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDelay : MonoBehaviour
{
    [SerializeField] Button buttonA;
    [SerializeField] Button buttonB;

    [SerializeField] float buttonShowDelay = 4; 
    
    void Start()
    {
        buttonA.gameObject.SetActive(false);
        buttonB.gameObject.SetActive(false);
    }

    void Update()
    {
        StartCoroutine(ShowButtons());
    }

    IEnumerator ShowButtons()
    {
        yield return new WaitForSecondsRealtime(buttonShowDelay);
        buttonA.gameObject.SetActive(true);
        buttonB.gameObject.SetActive(true);
    }
}
