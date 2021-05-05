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
    private ScoreManager mScoreManager;
    private int mScore;

    private void Start()
    {
        bounceCountText = BounceCounterUI.GetComponent<TextMeshProUGUI>();
        mScoreManager = FindObjectOfType<ScoreManager>();
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
        var score = new Score("joeDoe", mScore);
        mScoreManager.AddScore(score);
    }

    public void Replay()
    {
        Debug.Log("REPLAY");
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

}
