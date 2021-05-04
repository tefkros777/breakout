using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public GameObject GameOverUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("End oF Scene Trigger Crossed");

        GameOverUI.SetActive(true);

        // TODO: Show Game over scene
        // QuitGame();
    }

    private void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

}
