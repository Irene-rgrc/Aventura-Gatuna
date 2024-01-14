using UnityEngine;
using UnityEngine.Assertions;

public class Enemy : MonoBehaviour
{
    public EnemyAttributes Attributes;
    public int life;
    public int probability;
    public delegate void EnemyDeathEventHandler(int enemyType);
    public event EnemyDeathEventHandler OnEnemyDeath;
    public bool isAlive;


    private void Awake() //Inicializa al enemigo
    {
        Assert.IsNotNull(Attributes);
        Debug.Log($"{Attributes.enemyType} created. Life: {Attributes.maxLife}, Probability: {Attributes.maxProbability} ");
        //life = Attributes.maxLife; probability = Attributes.maxProbability;

    }
    private void Start()
    {
        GameObject currentEnemy = Connection.Instance.GetEnemy();
        if (currentEnemy != null)
        {
            Enemy enemyact = currentEnemy.GetComponent<Enemy>();
            enemyact.Damage();
        }
        
    }
    public int GetHealth()
    {
        return Attributes.maxLife;
    }

    public int GetProbability()
    {
        return Attributes.maxProbability;
    }

    public int SetHealth(int newLife)
    {
        Attributes.maxLife = newLife;

        // Verifica si la vida llegó a 0 y dispara el evento
        if (Attributes.maxLife <= 0)
        {
            OnEnemyDeath?.Invoke(Attributes.enemyType);
        }

        return Attributes.maxLife;
    }

    public int SetProbability(int newProbability)
    {
        Attributes.maxProbability = newProbability;
        return Attributes.maxProbability;
    }

    public int GetEnemyType()
    {
        return Attributes.enemyType;
    }
    public void MarkAsDead()
    {
        // Invoca el evento OnEnemyDeath y marca al enemigo como muerto
        OnEnemyDeath?.Invoke(Attributes.enemyType);
        gameObject.SetActive(false);
    }

    public int Damage() {

        Debug.LogError(Connection.Instance.GetWin());
        if (Connection.Instance.GetWin() == 2)
        {
            MarkAsDead();
            isAlive = false;
            Connection.Instance.SetLife(0);
            return 0;
        }
        return Attributes.maxLife;
    }


   
}