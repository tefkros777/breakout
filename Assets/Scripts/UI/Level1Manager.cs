using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level1Manager : MonoBehaviour
{
    public static bool TutorialActive;

    public GameObject PauseMenuUI;
    public GameObject TutorialUI;
    public GameObject ReplayUI;

    public Animator Anim;
    public Image img;

    public static event Action OnStageReset;

    private void Start()
    { 
        GameManager.instance.State = GameState.READY;
        ShowTutorial();
        GameOverScript.OnResetRequest += BeginReplay;
    }

    private void BeginReplay()
    {
        // Replay mode - Dont show tutorial.
        Debug.Log("BEGIN REPLAY");
        GameManager.instance.State = GameState.REPLAY;
        ReplayUI.SetActive(true);
        OnStageReset?.Invoke();
    }

    private void HideTutorial()
    {
        Debug.Log("Hiding Tutorial");
        TutorialUI.SetActive(false);
        Time.timeScale = 1f;
        GameManager.instance.State = GameState.READY;
        TutorialActive = false;
    }

    public void BeginGame()
    {
        HideTutorial();
        GameManager.instance.State = GameState.PLAYING;
    }

    void ShowTutorial()
    {
        Debug.Log("Showing Tutorial");
        TutorialUI.SetActive(true);
        Time.timeScale = 0f;
        GameManager.instance.State = GameState.PAUSED;
        TutorialActive = true;
    }

    public void Pause()
    {
        Debug.Log("PAUSED GAME");

        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameManager.instance.State = GameState.PAUSED;
    }

    public void Resume()
    {
        Debug.Log("RESUME GAME");
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameManager.instance.State = GameState.PLAYING;
    }

    public void LoadMainMenu()
    {
        Debug.Log("GO BACK TO MAIN MENU");
        // Time.timeScale = 1f;
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

        // If tutorial is shown disable pause menu
        if (!TutorialActive)
        {
            if (GameManager.instance.State == GameState.PAUSED)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void handleTextInput(string txt)
    {
        Debug.Log(txt);
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
