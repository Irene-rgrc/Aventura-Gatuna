using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GatoPlayer : MonoBehaviour
{

    public int maxLife=100;
    public int minMoney = 0;

    public GameOverManager gameOverManager;
    public FinalManager finalManager;

    public Slider sliderPlayer;

    private void Start()
    {
        if (Connection.Instance.GetLife() != 0) { maxLife = Connection.Instance.GetLife(); }

        Damage();
        
    }

    public void Damage()
    {
        if (Connection.Instance.GetWin() == 1) {
            maxLife -= 25;
            SetLife(maxLife);
            Connection.Instance.SetLife(maxLife);
        }
        
        Debug.LogError(maxLife);
        Scene currentScene = SceneManager.GetActiveScene();

        if (maxLife <= 0 && currentScene.name != "CoinFlip")
        {
                Die();
            
        }
        
        sliderPlayer.value = maxLife;
    }

public int GetLife ()
    {
        return maxLife;
    }

public int GetMoney()
    {
        return minMoney;
    }

    public void SetLife(int newLife)
    {
        maxLife = newLife;
    }

    public void SetMoney(int newMoney)
    {
       minMoney = newMoney;
    }


    private void Die()
    {
        
        Debug.LogError("Player has died!");
        gameOverManager.LoadGameOverScene();
    }
    public void Finals()
    {

        Debug.LogError("Player has died!");
        finalManager.SelectFinalScene();
    }

}