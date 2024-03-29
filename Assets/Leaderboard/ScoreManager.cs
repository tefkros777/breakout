using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ScoreManager : MonoBehaviour
{
    // Mono-singleton class
    public static ScoreManager instance { get; private set; }

    private ScoreData sd;

    private void Awake()
    {
        if (instance)
        {
            // Destroy the object if it already exists elsewhere in the code
            Destroy(gameObject);
            Debug.Log("SCOREMANAGER ALREADY EXISTS - DESTROYING GAME OBJECT");
        }
        else
        {
            // If it doesn't exist create it - This is the one
            instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("SCOREMANAGER INSTANCIATED");

            // Load Highscores
            LoadHighscores();

        }
    }

    public void ResetHighscores()
    {
        Debug.Log("Erasing highscores");
        PlayerPrefs.DeleteKey("leaderboards");
        LoadHighscores();
    }

    // Return the scores in descending order
    public IEnumerable<Score> GetHighscores()
    {
        return sd.scoreList.OrderByDescending(x => x.score);
    }

    // Add a new score to the list
    public void AddScore(Score score)
    {
        sd.scoreList.Add(score);
        Debug.Log($"Added Score {score.score}");
    }

    // Save all scores to PlayerPrefs
    public void SaveScore()
    {
        string json = JsonUtility.ToJson(sd);
        PlayerPrefs.SetString("leaderboards", json);
        Debug.Log("Saving Highscores");
    }

    // Save Highscores upon delete
    private void OnDestroy()
    {
        // Saved when exit button is called in main menu
        SaveScore();
    }

    private void LoadHighscores()
    {
        string json = PlayerPrefs.GetString("leaderboards", "{}");
        sd = JsonUtility.FromJson<ScoreData>(json);
    }

}
