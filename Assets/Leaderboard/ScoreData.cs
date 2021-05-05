using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScoreData
{
    public List<Score> scoreList;

    public ScoreData()
    {
        scoreList = new List<Score>();
    }
}
