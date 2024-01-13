using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController2 : MonoBehaviour
{
    private AnimationController2 animationController2;
    private GameManager2 gameManager2;

    private string playersChoice;

    private void Awake()
    {
        animationController2 = GetComponent<AnimationController2>();
        gameManager2 = GetComponent<GameManager2>();
    }
    // Crear una funcion que recoge la funcion de los botones de cara o cruz
    public void GetChoice()
    {

        string choiceName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        GameChoicesMoneda selectedChoice = GameChoicesMoneda.NONE;

        switch(choiceName)
        {
            case "Cara":
                selectedChoice = GameChoicesMoneda.CARA;
                break;
            case "Cruz":
                selectedChoice = GameChoicesMoneda.CRUZ;
                break;
        }
        gameManager2.SetChoices(selectedChoice);
        animationController2.PlayerMadeChoice();
    }
}
