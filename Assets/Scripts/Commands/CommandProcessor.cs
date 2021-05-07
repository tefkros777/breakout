using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CommandProcessor : MonoBehaviour
{
    private List<Command> mCommands = new List<Command>();
    private int mCurrentCommandIndex = -1;
    private int mReplayCommandIndex = 0;

    public void ExecuteCommand(Command command)
    {
        // Add command to the list
        if (command is BounceCommand)
        {
            // Dont store bounce commands, just execute them
            command.Execute();
        }
        else
        {
            mCommands.Add(command);
            command.Execute();
            mCurrentCommandIndex = mCommands.Count - 1; // Set the index to the end of the List
        }
    }

    public List<Command> GetCommands()
    {
        return mCommands;
    }

    public bool ReplayCommands()
    {
        // We must execute the first command
        if (mCommands.Count > mReplayCommandIndex)
        {
            mCommands[mReplayCommandIndex].Execute();
            mReplayCommandIndex++;
            return true;
        }
        else
        {
            mReplayCommandIndex = 0;
            return false;
        }
    }

}
