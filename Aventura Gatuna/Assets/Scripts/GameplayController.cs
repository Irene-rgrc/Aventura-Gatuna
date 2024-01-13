using Command.Interfaces;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameChoices
{
    NONE,
    ROCK,
    PAPER,
    SCISSORS
}

public class GameplayController : MonoBehaviour, IGameController
{
    [SerializeField]
    private Sprite rock_Sprite, paper_Sprite, scissors_Sprite;

    [SerializeField]
    private Image playerChoice_Img, opponentChoice_Img;

    [SerializeField]
    private TextMeshProUGUI infoText;

    private GameChoices player_Choice = GameChoices.NONE, opponent_Choice = GameChoices.NONE;

    private AnimationController animationController;

    private int enemy_prob;
    private int money;

    void Awake()
    {
        animationController = GetComponent<AnimationController>();
        enemy_prob = Connection.Instance.GetProbability();
        money = Connection.Instance.GetMoney();
    }

    public void SetChoices(GameChoices gameChoices)
    {
        switch(gameChoices)
        {
            case GameChoices.ROCK:

                playerChoice_Img.sprite = rock_Sprite;
                player_Choice = GameChoices.ROCK;

                break;
            case GameChoices.PAPER:

                playerChoice_Img.sprite = paper_Sprite;
                player_Choice = GameChoices.PAPER;

                break;
            case GameChoices.SCISSORS:

                playerChoice_Img.sprite = scissors_Sprite;
                player_Choice = GameChoices.SCISSORS;

                break;
        }
        SetOpponentChoice(player_Choice,enemy_prob); // METER AQUI LA ELECCION DEL JUGADORR!!!! SEGUN  LA PROBABILIDAD DEL ENEMIGO LUEGO DENTRO DEL METODO LO MULTIPLICO POR UN PORCENTAJE DE SACAR LA MANO GANADORA Y EL RESTO ES EL PORCENTAJE DE LAS OTRAS MANOS
        Connection.Instance.SetMoney(money);
        DetermineWinner();
    }

    void SetOpponentChoice()
    {
        int rnd = Random.Range(0, 3); // 0 ROCA 1 PAPEL 2 TIJERA AQUI MODIFICARIA SEGUN EL ENEMIGO LA PROBABILIDAD DE GANAR!!!!!!!! ES DECIR 
        switch (rnd)
        {
            case 0:
                opponent_Choice = GameChoices.ROCK;
                opponentChoice_Img.sprite = rock_Sprite;
                break;
            case 1:
                opponent_Choice = GameChoices.PAPER;
                opponentChoice_Img.sprite = paper_Sprite;
                break;
            case 2:
                opponent_Choice = GameChoices.SCISSORS;
                opponentChoice_Img.sprite = scissors_Sprite;
                break;
        }

    }

    void SetOpponentChoice(GameChoices player_Choice, int enemy_prob) // IMPORTAR AL ENEMIGO!!!!!!
    {
        int opponentWin = Random.Range(0, 101);

        if (opponentWin <=  (int) enemy_prob)
        {
            // ENEMIGO GANA
            if (player_Choice == GameChoices.ROCK) // PAPEL GANA
            {
                opponent_Choice = GameChoices.PAPER;
                opponentChoice_Img.sprite = paper_Sprite;
            }
            else if (player_Choice == GameChoices.PAPER)
            {
                opponent_Choice = GameChoices.SCISSORS;
                opponentChoice_Img.sprite = scissors_Sprite;
            }
            else if (player_Choice == GameChoices.SCISSORS)
            {
                opponent_Choice = GameChoices.ROCK;
                opponentChoice_Img.sprite = rock_Sprite;
            }
        }
        else
        {
            int rnd = Random.Range(0, 2); // Solo dos opciones debido a que debe de perder
            // ENEMIGO PIERDE
            if (player_Choice == GameChoices.ROCK) // PAPEL GANA
            {
                if (rnd <= 1)
                {
                    opponent_Choice = GameChoices.ROCK;
                    opponentChoice_Img.sprite = rock_Sprite;
                }
                else
                {
                    opponent_Choice = GameChoices.SCISSORS;
                    opponentChoice_Img.sprite = scissors_Sprite;
                }
            }
            else if (player_Choice == GameChoices.PAPER) // TIJERAS GANAS
            {
                if (rnd <= 1)
                {
                    opponent_Choice = GameChoices.ROCK;
                    opponentChoice_Img.sprite = rock_Sprite;
                }
                else
                {
                    opponent_Choice = GameChoices.PAPER;
                    opponentChoice_Img.sprite = paper_Sprite;
                }

            }
            else if (player_Choice == GameChoices.SCISSORS) // PIEDRA GANA
            {

                if (rnd <= 1)
                {
                    opponent_Choice = GameChoices.PAPER;
                    opponentChoice_Img.sprite = paper_Sprite;
                }
                else
                {
                    opponent_Choice = GameChoices.SCISSORS;
                    opponentChoice_Img.sprite = scissors_Sprite;
                }

            }
        }

      
    }

    void DetermineWinner()
    {
        if (player_Choice == opponent_Choice)
        {
            // EMPATE
            infoText.text = "Es un empate! :3 ";
            StartCoroutine(DisplayWinnerAndRestart()); // QUITAR ESTO SI NO QUEREMOS RE EMPEZAR
            return;
        }
        if ((player_Choice == GameChoices.PAPER && opponent_Choice == GameChoices.ROCK) || (player_Choice == GameChoices.ROCK && opponent_Choice == GameChoices.SCISSORS) || (player_Choice == GameChoices.SCISSORS && opponent_Choice == GameChoices.PAPER))
        {
            // JUGADOR GANA
            infoText.text = "Ganaste! <3 ";
            //StartCoroutine(DisplayWinnerAndRestart()); // QUITAR ESTO SI NO QUEREMOS RE EMPEZAR
            Connection.Instance.SetWin(true);
            StartCoroutine(ShowWinner());
            return;
        }
        if ((opponent_Choice == GameChoices.PAPER && player_Choice == GameChoices.ROCK) || (opponent_Choice == GameChoices.ROCK && player_Choice == GameChoices.SCISSORS) || (opponent_Choice == GameChoices.SCISSORS && player_Choice == GameChoices.PAPER))
        {
            // NPC GANA
            infoText.text = "Perdiste! :c ";
            Connection.Instance.SetWin(false);
            StartCoroutine(ShowWinner());
            //StartCoroutine(DisplayWinnerAndRestart()); // QUITAR ESTO SI NO QUEREMOS RE EMPEZAR
            return;
        }

        // PARA QUE SE EMPIEZE DE NUEVO
        IEnumerator DisplayWinnerAndRestart() // CO  RUTINA 
        {
            yield return new WaitForSeconds(2f); // Esperamos dos segundos
            infoText.gameObject.SetActive(true); // Quiero enseñarlo

            yield return new WaitForSeconds(2f);
            infoText.gameObject.SetActive(false); // No quiero enseñar mas

            animationController.ResetAnimations(); // Se resetea las animaciones

        }

        IEnumerator ShowWinner()
        {
            yield return new WaitForSeconds(2f);
            infoText.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("Dungeon2");
        }
    }

    public void SetEnemyProb(int enemy_prob)
    {
        this.enemy_prob = enemy_prob;
    }

    public int GetEnemyProb()
    {
        return enemy_prob;
    }

    public void SetMoney(int money)
    {
        this.money = money;
    }

    public int GetMoney()
    {
        return money;
    }
}
