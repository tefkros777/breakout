using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public GameObject GameOverUI;
    public Animator Anim;
    public Image img;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("End oF Scene Trigger Crossed");

        GameOverUI.SetActive(true);
    }

    public void Replay()
    {
        Debug.Log("REPLAY");
    }

    public void BackToMenu()
    {
        Debug.Log("BACK TO MENU");
        StartCoroutine(LoadMainMenuAsync());
    }

    IEnumerator LoadMainMenuAsync()
    {
        Anim.SetBool("Fade", true);
        yield return new WaitUntil(() => img.color.a == 1);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainMenu");

        // If loading is not finished
        while (!asyncLoad.isDone)
        {
            yield return null; // Not yet done
        }
    }

}
