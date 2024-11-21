using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoCanvasLevel2 : MonoBehaviour
{
    [SerializeField] float timeToDisappear = 5f;
    
    void Start()
    {
        gameObject.SetActive(true);
        StartCoroutine(CanvasDisappers());
    }

    IEnumerator CanvasDisappers()
    {
        yield return new WaitForSeconds(timeToDisappear);
        gameObject.SetActive(false);
    }
}
