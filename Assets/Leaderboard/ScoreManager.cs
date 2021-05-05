using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreManager : MonoBehaviour
{
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
            string json = PlayerPrefs.GetString("highscores", "{}");
            sd = JsonUtility.FromJson<ScoreData>(json);
        }
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
        PlayerPrefs.SetString("highscores", json);
    }

    // Save Highscores upon delete
    private void OnDestroy()
    {
        SaveScore();
    }

}
