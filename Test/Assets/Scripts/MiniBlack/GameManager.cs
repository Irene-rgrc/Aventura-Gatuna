using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    // CONDICION DE VICTORIA --- MIRIAM!!!!
    public bool victoria = true; // Esto seria como si siguiera vivo, en plan si la condicion de victoria se pone false entonces se acaba el juego asi que mientras siga vivo gana, NO LO SE SUOONGO

    // Botones de juego
    public Button tratoBtn;
    public Button hitBtn;
    public Button pararseBtn;

    private TextMeshProUGUI standBtnText;

    private int standClicks = 0; // Si se ha pulsado stand entonces se acaba el juego GAME OVER SIN CONDICION DE VICTORIA AUN!!!!!!!

    // para poder acceder al jugador y al enemigo 
    public PlayerScript playerScript;
    public PlayerScript dealerScript;
    // public Text mainText

    // Carta oculta del oponente
    
    // No apostamos asi que nada

    // Texto publico para acceder y actualizar HUD
    //private TextMeshProUGUI scoreText;
    public TextMeshProUGUI mainText;

    // Carta oculta del oponente
    public GameObject OcultarCarta;

    // public Button apostarBtn; // NO LO HACEMOS
    void Start()
    {
        // Cuando se pulsa se usa un ESCUCHA/LISTENER de los botones 
        tratoBtn.onClick.AddListener(() => TratoPulsado());
        hitBtn.onClick.AddListener(() => HitPulsado());
        pararseBtn.onClick.AddListener(() => PararsePulsado());
    }

    private void TratoPulsado() 
    {
        // RESETEA LA RONDA
        playerScript.ResetHand();
        dealerScript.ResetHand();
        
        mainText.gameObject.SetActive(false);

        // ESCONDE LA MANO DEL ENEMIGO AL EMPEZAR LA RONDA
        GameObject.Find("Deck").GetComponent<DeckScript>().Shuffle();
        playerScript.StartHand();
        dealerScript.StartHand();


        // Actualizar la suma de valores en el display
        //scoreText.text = "Mano: " + playerScript.handValue.ToString(); // playerScript.handValue.ToString();

        // SE ESCONDE, hide card
        OcultarCarta.GetComponent<Renderer>().enabled = true;

        // Ajustar los botones de visibilidad
        pararseBtn.gameObject.SetActive(true);
        hitBtn.gameObject.SetActive(true);
        tratoBtn.gameObject.SetActive(false);
        //standBtnText.text = "Pararse"; 
    }

    private void HitPulsado()
    {
        // Hay que comfirmar que el jugador tiene menos de 3 cartas en manos
        if (playerScript.cardIndex <= 3)
        {
            playerScript.GetCard();
            //scoreText.text = "Hand: " + playerScript.handValue.ToString();
            if (playerScript.handValue >= 4)
            {
                RoundOver(); 
            }
        }
    }

    private void PararsePulsado()
    {
        standClicks++;
        if (standClicks > 1) RoundOver();
        HitDealer();
        //standBtnText.text = "Call";
    }

    private void HitDealer() // ESTO ES LA FUNCION DE ROBAR PARA EL ENEMIGO AQUI SE DEBERIA DE IMPLEMENTAR
    // TAMBIEN LAS PROBABILIDADES O SI NO EN EL GETHAND, UNO ESPECIFICO PARA EL OPONENTE DE QUE TIENE MAS PROB DE UN BLACKJACK.
    {
        while (dealerScript.handValue < 3 && dealerScript.cardIndex < 3)
        {
            dealerScript.GetCard();
            if (dealerScript.handValue > 4) RoundOver();
        }
    }

    // Check for winnner and loser, hand is over
    void RoundOver()
    {
        // Booleans (true/false) PARA BUST ES DECIR SE PASA EL VALOR DE LA MANO DESDE EL PRINCIPO Y BLACKJACK -> 4
        bool playerBust = playerScript.handValue > 4;
        bool dealerBust = dealerScript.handValue > 4;
        bool player4 = playerScript.handValue == 4;
        bool dealer4 = dealerScript.handValue == 4;

        if (standClicks < 2 && !playerBust && !dealerBust && !player4 && !dealer4) return;
        bool roundOver = true;
        // Los dos pierden
        if (playerBust && dealerBust)
        {
            mainText.text = "Ambos pierden, se repite"; //  ------------------------------------------------------------------------------------------ PIERDEN AMBOS -> EMPATE
            victoria = true;
        }
        // if player busts, dealer didnt, or if dealer has more points, dealer wins
        else if (playerBust || (!dealerBust && dealerScript.handValue > playerScript.handValue))
        {
            mainText.text = "Perdiste!";
            victoria = false;    //  ------------------------------------------------------------------------------------------ PIERDE (no se si deberiamos añadir un wait antes de cambiar pantalla, si es necesario tu dimelo y lo hago)
        }
        // CONDICION DE VICTORIA
        else if (dealerBust || playerScript.handValue > dealerScript.handValue)
        {
            mainText.text = "Ganaste <3";
            //playerScript.Gana(true);
            victoria = true;  //  ------------------------------------------------------------------------------------------ GANA
        }
        //EMPATE
        else if (playerScript.handValue == dealerScript.handValue)
        {
            mainText.text = "Empate :3";
            victoria = true; //  ------------------------------------------------------------------------------------------ GANA
            //playerScript.Gana(true);
        }
        else
        {
            roundOver = false;
        }
        // Set ui up for next move / hand / turn
        if (roundOver)
        {
            OcultarCarta.GetComponent<Renderer>().enabled = false;
            // PRUEBA
        
            //
            hitBtn.gameObject.SetActive(false);
            pararseBtn.gameObject.SetActive(false);
            tratoBtn.gameObject.SetActive(true);
            mainText.gameObject.SetActive(true);
            standClicks = 0;
        }
    }
}
