using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Command.Commands;
using Command.Interfaces;
using TMPro;

public class BribingInputHandler : MonoBehaviour
{
    private static IGameController gameplayController;
    private CommandManager _commandManager;
    public TMP_Text bribeText;

    private void Awake()
    {
        _commandManager = new CommandManager();

        GameObject controller = GameObject.FindWithTag("GameController");
        if (controller.GetComponent<GameplayController>() != null) { gameplayController = controller.GetComponent<GameplayController>(); }
        //if (controller.GetComponent<FlipScript>() != null){ gameplayController = controller.GetComponent<FlipScript>();}
    }

    public void Bribe10()
    {
        ICommand command = new Bribe10(gameplayController, bribeText);
        _commandManager.ExecuteCommand(command);
    }

    public void Bribe5()
    {
        ICommand command = new Bribe5(gameplayController, bribeText);
        _commandManager.ExecuteCommand(command);
    }

    public void Undo()
    {
        _commandManager.UndoCommand();
    }
}