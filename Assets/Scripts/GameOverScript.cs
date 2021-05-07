using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public GameObject GameOverUI;
    public GameObject BounceCounterUI;
    public Animator Anim;
    public Image img;
    public TextMeshProUGUI ScoreLabel;

    public static event Action OnResetRequest;

    private TextMeshProUGUI bounceCountText;
    private int mScore;
    private string mActiveUserName;
    private CommandProcessor mCommandProcessor;

    private void Awake()
    {
        bounceCountText = BounceCounterUI.GetComponent<TextMeshProUGUI>();
        mActiveUserName = GameManager.instance.GetPlayerName();
        mCommandProcessor = FindObjectOfType<CommandProcessor>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Game Over");
        GameManager.instance.State = GameState.GAMEOVER;
        mScore = Int32.Parse(bounceCountText.text);
        ShowGameOverUI();
        UpdateLeaderboards();
    }

    private void ShowGameOverUI()
    {
        GameOverUI.SetActive(true);
        BounceCounterUI.SetActive(false);
        ScoreLabel.text = "SCORE: " + mScore;
    }

    private void HideGameOverUI()
    {
        GameOverUI.SetActive(false);
        BounceCounterUI.SetActive(true);
    }

    private void UpdateLeaderboards()
    {
        var score = new Score(mActiveUserName, mScore);
        ScoreManager.instance.AddScore(score);
    }

    public void Replay()
    {
        Debug.Log("REPLAY");
        // TODO: RESTART LEVEL REMEMBERING COMMAND LIST

        // Save commands from this session into the game manager
        GameManager.instance.ReplayCommands = mCommandProcessor.GetCommands();
        GameManager.instance.State = GameState.REPLAY;

        // Hide Gameover menu
        HideGameOverUI();

        // Restart Level
        // RestartLevel(); // TODO: WHEN RESTARTING FOR REPLAY, PREVENT USER INPUT AND HIDE 

        // Anounce to all objects to reset
        OnResetRequest?.Invoke();

    }

    public void RestartLevel()
    {
        Debug.Log("Restart Level");
        StartCoroutine(ReloadSceneAsync());
    }

    public void BackToMenu()
    {
        Debug.Log("BACK TO MENU");
        StartCoroutine(LoadMainMenuAsync());
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

    IEnumerator ReloadSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level1");

        // If loading is not finished
        while (!asyncLoad.isDone)
        {
            yield return null; // Not yet done
        }
    }

}
