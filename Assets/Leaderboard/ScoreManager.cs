using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreManager : MonoBehaviour
{
    private ScoreData sd;

    private void Awake()
    {
        // Load Highscores
        string json = PlayerPrefs.GetString("highscores", "{}");
        sd = JsonUtility.FromJson<ScoreData>(json);
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
