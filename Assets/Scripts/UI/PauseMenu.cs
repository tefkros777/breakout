using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused;

    public GameObject PauseMenuUI;

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

    public void LoadMainMenu()
    {
        Debug.Log("GO BACK TO MAIN MENU");
        Time.timeScale = 1f;
        StartCoroutine(LoadMainMenuAsync());
    }

    public void Restart()
    {
        Debug.Log("RESTARTING LEVEL");
        Time.timeScale = 1f;

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

    IEnumerator LoadMainMenuAsync()
    {
/*        Anim.SetBool("Fade", true);
        yield return new WaitUntil(() => img.color.a == 1);*/

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainMenu");

        // If loading is not finished
        while (!asyncLoad.isDone)
        {
            yield return null; // Not yet done
        }
    }
}
