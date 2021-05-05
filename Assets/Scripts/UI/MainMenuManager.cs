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
    public TMP_InputField UsernameField;

    private string username;

    private void Awake()
    {
        UsernameField.onEndEdit.AddListener(handleTextInput); // For username input
        username = UsernameField.text;
    }

    private void Start()
    {
        UsernameField.text = GameManager.instance.GetPlayerName();
    }

    private void handleTextInput(string txt)
    {
        GameManager.instance.SetPlayerName(txt);
    }

    public void LaunchLeaderboards()
    {
        Debug.Log("LEADERBOARDS");
        StartCoroutine(LoadLeaderboardsAsync());
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

    IEnumerator LoadLeaderboardsAsync()
    {
        Anim.SetBool("Fade", true);
        yield return new WaitUntil(() => img.color.a == 1);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Leaderboards");

        // If loading is not finished
        while (!asyncLoad.isDone)
        {
            yield return null; // Not yet done
        }
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
