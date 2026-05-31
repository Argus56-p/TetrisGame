using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void OpenMenu()
    {
        SceneManager.LoadScene(0);
    }


    public void goToNextLevel()
    {
        SceneManager.LoadScene(2);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
        //Application.LoadLevel(Application.LoadedLevel);
    }
}
