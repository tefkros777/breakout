using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandProcessor : MonoBehaviour
{
    private List<Command> mCommands = new List<Command>();
    private int mCurrentCommandIndex = -1;

    public void ExecuteCommand(Command command)
    {
        // Add command to the list
        mCommands.Add(command);
        command.Execute();
        mCurrentCommandIndex = mCommands.Count - 1; // Set the index to the end of the List
    }

    public List<Command> GetCommands()
    {
        return mCommands;
    }

}
