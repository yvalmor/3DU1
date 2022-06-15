using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadInterface : MonoBehaviour
{
    public CanvasGroup popUpReload;

    private void Start()
    {
        popUpReload.alpha = 0;
        popUpReload.gameObject.SetActive(false);
    }

    public void FadeIn()
    {
        popUpReload.gameObject.SetActive(true);
        StartCoroutine(FadeCanvasGroup(0, 1, 2));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeCanvasGroup(1, 0, 2));
    }

    // Function to fade in or fade out a CanvasGroup
    private IEnumerator FadeCanvasGroup(float start, float end, float lerpTime = 0.5f)
    {
        float currValue = start;
        
        while (Math.Abs(currValue - end) > 0.01)
        {
            currValue = Mathf.Lerp(currValue, end, Time.deltaTime * lerpTime);
            popUpReload.alpha = currValue;

            yield return new WaitForEndOfFrame();
        }
        
        if (end == 0)
            popUpReload.gameObject.SetActive(false);
    }
    
}
