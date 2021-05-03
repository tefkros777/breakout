using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused;

    public GameObject PauseMenuUI;


    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        Debug.Log("PAUSED GAME");

        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void Resume()
    {
        Debug.Log("RESUME GAME");
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void MainMenu()
    {
        Debug.Log("GO BACK TO MAIN MENU");

    }

    public void PauseToggle()
    {
        Debug.Log("PAUSED TOGGLE");
        
        if (IsPaused)
        {
            Resume();
        } else 
        {
            Pause();
        }

    }
}
