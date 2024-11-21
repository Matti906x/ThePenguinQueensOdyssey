using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Camera myCamera;
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }

    void Update() 
    {
        transform.rotation = myCamera.transform.rotation;
        transform.position = target.position + offset;
    }
}
