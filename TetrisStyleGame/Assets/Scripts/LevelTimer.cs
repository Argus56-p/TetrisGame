using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{
    public float levelTime;
    public TextMeshProUGUI timerText;
    public GameObject timeOverPanel;
    private float currentTime;
    private bool ended = false;
    public TextMeshProUGUI timeOverText;
    void Start()
    {
        Time.timeScale = 1f;
        currentTime = levelTime;
        timeOverPanel.SetActive(false);
    }


    void Update()
    {
        if (ended) return;
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            currentTime = 0;
            EndGame();


        }
        int t = Mathf.CeilToInt(currentTime);
        timerText.text = "Time: " + t;
    }

    void EndGame()
    {
        ended = true;
        timeOverPanel.SetActive(true);
        Time.timeScale = 0f;
        int score = MyGameManager.instance.score;
        timeOverText.text = "Round is over \n Score is: " + score;

    }

}  
