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
    public GameObject ReplayUI;
    public Animator Anim;
    public Image img;
    public TextMeshProUGUI ScoreLabel;

    public static event Action OnResetRequest;

    private TextMeshProUGUI bounceCountText;
    private int mScore;
    private string mActiveUserName;

    private void Awake()
    {
        bounceCountText = BounceCounterUI.GetComponent<TextMeshProUGUI>();
        mActiveUserName = GameManager.instance.GetPlayerName();
    }

    private void Update()
    {
        if (GameManager.instance.State == GameState.REPLAY_FINISHED)
        {
            Debug.Log("REPLAY FINISHED");

            GameOver();
        };
    }

    // When ball falls out of screen
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameOver();
    }

    private void GameOver()
    {
        if (GameManager.instance.State == GameState.REPLAY_ACTIVE) 
            return; 
        Debug.Log("Game Over");
        ShowGameOverUI();
        CalculateScore();
        if (GameManager.instance.State != GameState.REPLAY_FINISHED) 
            UpdateLeaderboards();
        GameManager.instance.State = GameState.GAMEOVER;
    }

    private void ShowGameOverUI()
    {
        GameOverUI.SetActive(true);
        BounceCounterUI.SetActive(false);
    }

    private void CalculateScore()
    {
        mScore = Int32.Parse(bounceCountText.text);
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
        Debug.Log("REPLAY BUTTON PRESSED");

        HideGameOverUI();

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
