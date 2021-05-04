using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level1Manager : MonoBehaviour
{
    public static bool IsPaused;
    public static bool TutorialActive;

    public GameObject PauseMenuUI;
    public GameObject TutorialUI;
    public Animator Anim;
    public Image img;

    private void Start()
    {
        ShowTutorial();
    }

    public void HideTutorial()
    {
        Debug.Log("Hiding Tutorial");
        TutorialUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        TutorialActive = false;
    }

    void ShowTutorial()
    {
        Debug.Log("Showing Tutorial");
        TutorialUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
        TutorialActive = true;
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

        if (!TutorialActive)
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    IEnumerator LoadMainMenuAsync()
    {
        Anim.SetBool("Fade", true);
        yield return new WaitUntil(() => img.color.a == 1);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainMenu");

        // If loading is not finished
        while (!asyncLoad.isDone)
        {
            yield return null; // Not yet done
        }
    }
}
