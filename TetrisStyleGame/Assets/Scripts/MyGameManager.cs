using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyGameManager : MonoBehaviour
{
    public static MyGameManager instance;
    public TextMeshProUGUI scoreText;
    public GameObject gameoverText;

    public int score;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        gameOver = false;
        UpdateScoreUI();

    }

    public  void Awake()
    {
        instance = this;
    }


    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    public void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    public void ShowGameOver()
    {
        gameOver = true;
        gameoverText.SetActive(true);
    }
    
    public bool IsGameOver()
    {
        return gameOver;
    }



}
