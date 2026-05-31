using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource musicSource;
    public AudioSource effectsSource;
    public AudioClip musicClip;
    public AudioClip lineClearClip;
    public AudioClip gameOverClip;

    private bool restarting = false;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        musicSource.clip = musicClip;
        musicSource.loop = true;
        musicSource.volume = 1f;
        musicSource.Play();
    }


    public void PlayLineClear()
    {
        effectsSource.PlayOneShot(lineClearClip);
        
            
    }

    public void PlayGameOver()
    {
        effectsSource.PlayOneShot(gameOverClip);
    }


    public void FadeMusicAndRestart(float delayBeforeRestart)
    {
        if (restarting) return;
        restarting = true;
        StartCoroutine(FadeAndRestart(delayBeforeRestart));
    }

    IEnumerator FadeAndRestart(float delay)
    {
        float startVolume = musicSource.volume;
        float time = 0f;

        while (time < delay)
        {
            time += Time.deltaTime;
            musicSource.volume = Mathf.Lerp(startVolume, 0f, time / delay);
            yield return null;

        }


        musicSource.Stop();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    
    void Update()
    {
        
    }
}
