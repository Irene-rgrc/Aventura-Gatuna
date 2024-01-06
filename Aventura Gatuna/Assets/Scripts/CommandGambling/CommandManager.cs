using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Command.Interfaces;

public class CommandManager
{
    private List<ICommand> executedCommands = new List<ICommand>();
    private int max = 3;
    private int lastExecutedCommand = 0;

    public void ExecuteCommand(ICommand command)
    {
        if (executedCommands.Count<max) {
            command.Execute();

            executedCommands.Add(command);
            lastExecutedCommand = executedCommands.Count - 1;
        }
    }

    public void UndoCommand()
    {
        if (lastExecutedCommand > -1)
        {
            ICommand lastCommand = executedCommands[lastExecutedCommand];
            lastCommand.Undo();
            executedCommands.RemoveAt(lastExecutedCommand);
            lastExecutedCommand -= 1;
        }
        else
        {
            Debug.Log("No more commands to UNDO");
        }
    }

    /*public void RedoCommand()
    {
        if (lastExecutedCommand < executedCommands.Count - 1)
        {
            ICommand lastCommand = executedCommands[lastExecutedCommand + 1];
            lastCommand.Execute();
            lastExecutedCommand += 1;
        }
        else
        {
            Debug.Log("No more commands to REDO");
        }
    }*/
}