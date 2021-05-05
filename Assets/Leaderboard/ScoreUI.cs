using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public RowUI RowUI;
    public ScoreManager ScoreManager;

    void Start()
    {
        ScoreManager.AddScore(new Score("erdogan", 5));
        ScoreManager.AddScore(new Score("macron", 99));

        Score[] scores = ScoreManager.GetHighscores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            RowUI row = Instantiate(RowUI, transform).GetComponent<RowUI>();
            row.Rank.text = (i + 1).ToString();
            row.Name.text = scores[i].name;
            row.Score.text = scores[i].score.ToString();
        }

    }
}
