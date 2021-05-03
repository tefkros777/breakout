using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    
    public void LaunchGame()
    {
        Debug.Log("Launching Level");
        StartCoroutine(LoadLevel1Async());
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }

    // Co-routine - Keep checking for if the scene is loaded
    IEnumerator LoadLevel1Async()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level1");
        
        // If loading is not finished
        while (!asyncLoad.isDone)
        {
            yield return null; // Not yet done
        }
    }

}
