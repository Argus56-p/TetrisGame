using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PanelOpen : MonoBehaviour
{
    public GameObject panel;
    public bool panelIsActive;
    void Start()
    {
        panelIsActive = true;
        panel.SetActive(false);
    }

  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& !panelIsActive)
        {
            panel.SetActive(true);
            panelIsActive = true;
        }

        else if(Input.GetKeyDown(KeyCode.Space)&& panelIsActive)
        {
            panel.SetActive(false);
            panelIsActive = false;
        }
    }
}
