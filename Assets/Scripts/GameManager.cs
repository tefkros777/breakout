using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    // public string ActivePlayerName { get; set; }

    public GameState State { get; set; }

    public List<Command> ReplayCommands { get; set; }

    private void Awake()
    {
        if (instance)
        {
            // Destroy the object if it already exists elsewhere in the code
            Destroy(gameObject);
            Debug.Log("GAME MANAGER ALREADY EXISTS - DESTROYING GAME OBJECT");
        }
        else
        {
            // If it doesn't exist create it - This is the one
            instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("GAME MANAGER INSTANCIATED");
        }
    }

    public string GetPlayerName()
    {
        return PlayerPrefs.GetString("username", "UNKNOWN_PLAYER");
    }

    public void SetPlayerName(string username)
    {
        PlayerPrefs.SetString("username", username);
    }

}
