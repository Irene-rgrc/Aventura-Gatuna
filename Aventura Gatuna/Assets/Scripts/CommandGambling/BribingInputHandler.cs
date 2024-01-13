using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Command.Commands;
using Command.Interfaces;
using TMPro;

public class BribingInputHandler : MonoBehaviour
{
    private static GameplayController gameplayController;
    private CommandManager _commandManager;
    public TMP_Text bribeText;

    private void Awake()
    {
        _commandManager = new CommandManager();

        GameObject controller = GameObject.FindWithTag("GameController");
        if (controller.GetComponent<GameplayController>() != null) { gameplayController = controller.GetComponent<GameplayController>(); }
        bribeText.text = "Soborno:\r\n\tProbabilidad del enemigo: " + Connection.Instance.GetProbability() + "%\r\n\tTienes: " + Connection.Instance.GetMoney() + " monedas";
    }

    public void Bribe10()
    {
        if (gameplayController.GetMoney()>900)
        {
            ICommand command = new Bribe10(gameplayController, bribeText);
            _commandManager.ExecuteCommand(command);
        }
    }

    public void Bribe5()
    {
        if (gameplayController.GetMoney() > 500)
        {
            ICommand command = new Bribe5(gameplayController, bribeText);
            _commandManager.ExecuteCommand(command);
        }
    }

    public void Undo()
    {
        _commandManager.UndoCommand();
    }
}