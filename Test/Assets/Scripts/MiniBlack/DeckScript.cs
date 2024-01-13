using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckScript : MonoBehaviour
{
    public Sprite[] cardSprites;
    int[] cardValues = new int[6]; // SON 5 CARTAS PERO SI PONGO 5 ME PONE QUE EL ARRAY ES MUY CORTO SOS
    int currentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetCardValues();
    }

    // Update is called once per frame
    void GetCardValues()
    {
        int num = 0;
        // bucle para asignar el valor de las cartas
        for (int i = 0; i < cardSprites.Length; i++)  // ESTO NO SE SI FUNCIONA
        {
            num = i;
            cardValues[i] = num++;
        }
        //currentIndex = 1;
    }

    public void Shuffle()
    {
        for(int i = cardSprites.Length - 1; i > 0; --i) // Cuento el tamaño del array hacia atras y quito uno de la distancia
        {
            //int j = Mathf.FloorToInt(Random.Range(0.0f, 1.0f) * cardSprites.Length - 1) + 1; // Utilizamos valores randoms que esten dentros de los valores de la carte
            // int j = Mathf.FloorToInt(Random.Range(0.0f, 1.0f) * cardSprites.Length - 1) + 1;
            // Reasignacion de valores -> se remplaza con j que es el random nuevo donde antes estaba i
            int j = Mathf.FloorToInt(Random.Range(0.0f, 1.0f) * cardSprites.Length - 1) + 1;
            Sprite face = cardSprites[i];
            cardSprites[i] = cardSprites[j];
            cardSprites[j] = face;

            int value = cardValues[i];
            cardValues[i] = cardValues[j];
            cardValues[j] = value;
        }
        currentIndex = 1;
    }

    public int TratoCarta(CartaScript cardScript)
    {
        cardScript.SetSprite(cardSprites[currentIndex]);
        cardScript.SetValue(cardValues[currentIndex]);
        currentIndex++;
        return cardScript.GetValueOfCard();
    }

    public Sprite GetCardBack()
    {
        return cardSprites[0];
    }
}
