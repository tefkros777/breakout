using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreManager : MonoBehaviour
{
    private ScoreData sd;

    private void Awake()
    {
        sd = new ScoreData();
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
}
