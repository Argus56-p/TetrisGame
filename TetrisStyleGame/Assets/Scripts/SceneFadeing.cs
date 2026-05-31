using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFadeing : MonoBehaviour
{
    public CanvasGroup myCanvasGroup;
    public float fadeduration;
    void Start()
    {
        StartCoroutine(FadeIn());
    }

   IEnumerator FadeIn()
   {
        float time = 0;
        myCanvasGroup.alpha = 1;
        while(time < fadeduration)
        {
            time += Time.deltaTime;
            float t = time / fadeduration;
            myCanvasGroup.alpha = Mathf.Lerp(1f, 0f, t);
            yield return null;
        }
        myCanvasGroup.alpha = 0;
        gameObject.SetActive(false);
   }
    



}
