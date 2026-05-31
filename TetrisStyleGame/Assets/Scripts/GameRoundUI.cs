using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRoundUI : MonoBehaviour
{
    public GameObject dropDownMenu;
   


    
    void Start()
    {
        dropDownMenu.SetActive(false);
        Time.timeScale = 1f;
    }


    public void pressOptionsButton()
    {
        dropDownMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void Resume()
    {
        dropDownMenu.SetActive(false);
        Time.timeScale = 1f;
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    void Update()
    {
        
    }
}
