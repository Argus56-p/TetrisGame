using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ButtonScale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{

    private Vector3 normalScale;
    private Vector3 targetScale;

    public float hoverScale;
    public float pressedScale;
    public float speed;

    void Start()
    {
        normalScale = transform.localScale;
        targetScale = normalScale;

    }


    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * speed);
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        targetScale = normalScale * hoverScale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetScale = normalScale;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        targetScale = normalScale * pressedScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        targetScale = normalScale * hoverScale;
    }
}
