using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearScoresScript : MonoBehaviour
{
    public Animator Anim;
    public Image img;

    public void ClearScores()
    {
        StartCoroutine(DeleteHighscorePlayerPrefsAsync());
    }

    IEnumerator DeleteHighscorePlayerPrefsAsync()
    {
        Anim.SetBool("Fade", true);
        yield return new WaitUntil(() => img.color.a == 1);

        ScoreManager.instance.ResetHighscores();

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Leaderboards");

        // If loading is not finished
        while (!asyncLoad.isDone) yield return null;
    }
}
