using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }

    public void AddPoints(int points)
    {
        score += points;
        UpdateUI();
    }

     void UpdateUI()
     {
        scoreText.text = "Points: " + score;
     }
    

    public void ResetScore()
    {
        score =  0;
        UpdateUI();
    }
}
