using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    public Animator Anim;
    public Image img;

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
