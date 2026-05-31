using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;
    Vector3 originalPos;
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        originalPos = transform.position;
    }

    public void Shake( float duration, float strenght)
    {
        StartCoroutine(ShakeRoutine(duration, strenght));
        
    }
    IEnumerator ShakeRoutine(float duration, float strenght)
    {
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            float offsetX = Random.Range(-1f, 1f) * strenght;
            float offsetY = Random.Range(-1f, 1f) * strenght;
            transform.position = originalPos + new Vector3(offsetX, offsetY, 0);
            yield return null;
        }

        transform.position = originalPos;
    }

    void Update()
    {
        
    }
}
