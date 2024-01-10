using UnityEngine;

public class GatoPlayer : MonoBehaviour
{

    public int maxLife = 100;
    public int minMoney = 0;

    public int currentLife;
    public int currentMoney;

    int damageAmount;

    public GameOverManager gameOverManager;


    private void Start()
    {
        StartPlayer();
    }

    private void StartPlayer ()
    {
        currentLife = maxLife; currentMoney = minMoney; damageAmount = 25;
    }
    private void Update() //esto es solo para hacer comprobaciones
    {
        // Verifica si la tecla de espacio fue presionada
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Llama al método TakeDamage al presionar la tecla de espacio
            Damage();
        }
    }
    public void Damage()
    {
        Debug.LogError(currentLife);
        currentLife -= damageAmount;
        setLife(currentLife);

        if (currentLife <= 0)
        {
            Die();
        }
    }

public int getLife ()
    {
        return currentLife;
    }

public int getMoney()
    {
        return currentMoney;
    }

    public void setLife(int newLife)
    {
        currentLife = newLife;
    }

    public void setMoney(int newMoney)
    {
        currentMoney = newMoney;
    }


    private void Die()
    {
        Debug.LogError("Player has died!");
        gameOverManager.LoadGameOverScene();
    }

}