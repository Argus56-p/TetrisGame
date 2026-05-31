using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeManager : MonoBehaviour
{
    
   public void EasyMode()
   {
        //Time.timeScale = 1f;
        PlayerPrefs.SetFloat("fallTime", 0.7f);
        PlayerPrefs.SetFloat("fastFallTime", 0.4f);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
   }



    public void NormalMode()
    {
        //Time.timeScale = 5f;
        PlayerPrefs.SetFloat("fallTime", 0.2f);
        PlayerPrefs.SetFloat("fastFallTime", 0.1f);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }

    public void HardMode()
    {
        //Time.timeScale = 10f;
        PlayerPrefs.SetFloat("fallTime", 0.1f);
        PlayerPrefs.SetFloat("fastFallTime", 0.05f);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }
}
