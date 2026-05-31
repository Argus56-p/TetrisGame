using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFade : MonoBehaviour
{
    public CanvasGroup myCanva;
    public float fadeSpeed;
   
    void Start()
    {
        myCanva.alpha = 0f;

    }

   
    void Update()
    {
        if (myCanva.alpha < 1f)
        {
            myCanva.alpha += fadeSpeed;
        }
    }
}
