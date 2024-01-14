using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public enum GameChoicesMoneda
{
    NONE,
    CARA,
    CRUZ
}

public class GameManager2 : MonoBehaviour
{
    public bool victoria = true;

    [SerializeField]
    private Sprite cara_Sprite, cruz_Sprite;

    [SerializeField]
    private Image moneda_Img; // Imagen de la moneda cual va a ser cara o cruz

    [SerializeField]
    private TextMeshProUGUI infoText;

    private GameChoicesMoneda player_Choice = GameChoicesMoneda.NONE;
    private GameChoicesMoneda moneda_Choice = GameChoicesMoneda.NONE;

    private AnimationController2 animationController2;

    internal void SetChoices(GameChoicesMoneda gameChoiceMoneda)
    {
        switch (gameChoiceMoneda)
        {
            case GameChoicesMoneda.CARA:
                player_Choice = GameChoicesMoneda.CARA;
                break;
            case GameChoicesMoneda.CRUZ:
                player_Choice = GameChoicesMoneda.CRUZ;
                break;
        }
 
        SetMonedaChoice();
        // La moneda sacara cara siempre, se lo dejamos saber en el texto, "Intuyo que la moneda sera cara..." por si quieren dejar ganar al gato
        DetermineWinner();
    }

    private void SetMonedaChoice()
    {
        moneda_Choice = GameChoicesMoneda.CARA;
        moneda_Img.sprite = cara_Sprite;
        /*int rnd = Random.Range(0, 2);
        switch (rnd)
        {
            case 0: // CARA
                moneda_Choice = GameChoicesMoneda.CARA;
                moneda_Img.sprite = cara_Sprite;
                break;
            case 1: // CRUZ
                moneda_Choice = GameChoicesMoneda.CRUZ;
                moneda_Img.sprite = cruz_Sprite;
                break;
        }*/
    }

    private void DetermineWinner()
    {
        if(player_Choice == moneda_Choice) // MONEDA ES CARA POR LO TANTO SI EL JUGADOR ELIGUE CARA GANA
        {
            infoText.text = "Has ganado <3!";
            victoria = true;
            Connection.Instance.SetCoinWin(1);
        } else
        {
            infoText.text = "Has perdido! :c";
            victoria = false;
            Connection.Instance.SetCoinWin(2);
        }
        infoText.gameObject.SetActive(true);
    }
    /*
public FlipScript coin;
public bool victoria = true;
public bool botonPulsado = false;
public bool cara = false;
public bool cruz = false;

public Button caraBtn;
public Button cruzBtn;

public Sprite caraSprite;  // Asigna el sprite correspondiente a cara desde el Inspector
public Sprite cruzSprite;  // Asigna el sprite correspondiente a cruz desde el Inspector

private void Start()
{
caraBtn.gameObject.SetActive(true);
cruzBtn.gameObject.SetActive(true);

caraBtn.onClick.AddListener(() => CaraPulsado());
cruzBtn.onClick.AddListener(() => CruzPulsado());
}

private void CruzPulsado()
{
cruz = true;
caraBtn.gameObject.SetActive(false);
cruzBtn.gameObject.SetActive(false);
RoundOver();
}

private void CaraPulsado()
{
cara = true;
caraBtn.gameObject.SetActive(false);
cruzBtn.gameObject.SetActive(false);
RoundOver();
}

private void RoundOver()
{
if (cara || cruz)
{
  int girosTotales = Random.Range(2, 11);
  coin.FlipCoin(0.04f, girosTotales);
  coin.gameObject.SetActive(false);

  // Condicion de victoria y derrota
  if ((cara && coin.spriteRenderer.sprite == caraSprite) || (cruz && coin.spriteRenderer.sprite == cruzSprite))
  {
      Debug.Log("¡Has ganado!");
      victoria = true;
  }
  else
  {
      Debug.Log("¡Has perdido!");
  }
}
}*/
}
