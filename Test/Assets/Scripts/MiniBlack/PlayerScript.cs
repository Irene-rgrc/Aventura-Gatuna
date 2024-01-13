using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    // ESTE ES SCRIPT ES VALIDO TANTO COMO AL PLAYER COMO AL ENEMIGO

    // Pillamos los otros scripts
    public CartaScript cartaScript;
    public DeckScript deckScript;

    // total del valor en la mano del jugador/enemigo
    public int handValue = 0;

    // Apuesta dinero
    //private int money = 1000;

    // ARRAY DE LAS CARTAS OBJETOS QUE ESTAN EN LA MESA
    public GameObject[] hand;
    // Index de la carta siguiente
    public int cardIndex = 0;
    // Seguimiento de las conversiones de 1 al 5
    List<CartaScript> aceList = new List<CartaScript>();

    // Start is called before the first frame update
    public void StartHand()
    {
        GetCard();
        //GetCard();
    }

    // Agrega una carta al jugador
    public int GetCard()
    {
        cardIndex++;
        // coge carta, usar la trato carta para asignarsela al sprite y al valor de la carta en la mesa
        int cardValue = deckScript.TratoCarta(hand[cardIndex].GetComponent<CartaScript>());
        // enseñar la carta en el juego
        hand[cardIndex].GetComponent<Renderer>().enabled = true;
        // Agregamos el valor de la carta al total de la mano
        handValue += cardValue;
        // Si el valor es un 1, es un ace
        if (cardValue == 1)
        {
            aceList.Add(hand[cardIndex].GetComponent<CartaScript>());
        }
        return handValue;
    }

    // ESTA FUNCION ES DEL TUTORIAL VIDEO 3 MIN 23MIN NO ESTA IMPLEMENTADA PORQUE NO TENEMOS UN ACE!!!!!!!!!
    public void AceCheck()
    {
        // for each ace in the lsit check
        foreach (CartaScript ace in aceList)
        {
            if (handValue + 10 < 22 && ace.GetValueOfCard() == 1)
            {
                // if converting, adjust card object value and hand
                ace.SetValue(11);
                handValue += 10;
            }
            else if (handValue > 21 && ace.GetValueOfCard() == 11)
            {
                // if converting, adjust gameobject value and hand value
                ace.SetValue(1);
                handValue -= 10;
            }
        }
    }

    // Hides all cards, resets the needed variables
    public void ResetHand()
    {
        for (int i = 0; i < hand.Length; i++)
        {
            hand[i].GetComponent<CartaScript>().ResetCard();
            hand[i].GetComponent<Renderer>().enabled = false;
        }
        cardIndex = 0;
        handValue = 0;
        aceList = new List<CartaScript>();
    }
}
