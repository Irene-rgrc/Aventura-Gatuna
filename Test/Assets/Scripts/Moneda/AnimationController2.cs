using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController2 : MonoBehaviour
{
    [SerializeField]
    private Animator playerChoiceHandlerAnimation, choiceAnimation;

    public void ResetAnimations() 
    {
       
    } // NO VA A HACER FALTA, ES JUEGO FINAL

    public void PlayerMadeChoice()
    {
        playerChoiceHandlerAnimation.Play("RemoveHandler");
        choiceAnimation.Play("ShowChoices");
    }
}
