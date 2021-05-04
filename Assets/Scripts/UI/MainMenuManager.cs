using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Animator Anim;
    public Image img;
    public TextMeshProUGUI HighscoreLabel;

    private void Start()
    {
        HighscoreLabel.text = "HIGHSCORE: " + BounceCounter.Highscore;
    }

    public void LaunchGame()
    {
        Debug.Log("Launching Level");
        StartCoroutine(LoadLevel1Async());
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
        StartCoroutine(QuitWithTransition());
    }

    IEnumerator QuitWithTransition()
    {
        Anim.SetBool("Fade", true);
        yield return new WaitUntil(() => img.color.a == 1);
       
        #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    // Co-routine - Keep checking for if the scene is loaded
    IEnumerator LoadLevel1Async()
    {
        Anim.SetBool("Fade", true);
        yield return new WaitUntil(() => img.color.a == 1);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level1");
        
        // If loading is not finished
        while (!asyncLoad.isDone)
        {
            yield return null; // Not yet done
        }
    }

}
