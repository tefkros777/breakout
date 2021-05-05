using System;
using System.Collections;
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

    private TextMeshProUGUI bounceCountText;
    private int mScore;
    private string mActiveUserName;

    private void Awake()
    {
        bounceCountText = BounceCounterUI.GetComponent<TextMeshProUGUI>();
        mActiveUserName = GameManager.instance.GetPlayerName();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Game Over");
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

    private void UpdateLeaderboards()
    {
        var score = new Score(mActiveUserName, mScore);
        ScoreManager.instance.AddScore(score);
    }

    public void Replay()
    {
        Debug.Log("REPLAY");
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
