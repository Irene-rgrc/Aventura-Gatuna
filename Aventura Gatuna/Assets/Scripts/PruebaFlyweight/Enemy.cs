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
    private int ID;

    public void SetID(int ID) { this.ID = ID; }
    public int GetID() { return ID; }
    private void Awake() //Inicializa al enemigo
    {
        Assert.IsNotNull(Attributes);
        Invoke("Actualizar", 1.5f);
        //Debug.Log($"{Attributes.enemyType} created. Life: {Attributes.maxLife}, Probability: {Attributes.maxProbability} ");
        //life = Attributes.maxLife; probability = Attributes.maxProbability;

    }

    void Actualizar()
    {
        if (GameObject.FindWithTag("EnemyManager").GetComponent<EnemyManager>().GetEnemyManagerSO(ID) == false) { Damage(); }
    }
    private void Start()
    {
        Invoke("Comprobar", 1.0f);   
    }

    void Comprobar()
    {
        //GameObject currentEnemy = Connection.Instance.GetEnemy();
        if (ID == Connection.Instance.GetEnemy() /*&& Connection.Instance.GetWin() == 1*/)
        {
            //Enemy enemyact = currentEnemy.GetComponent<Enemy>();
            Damage();
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
        MarkAsDead();
        isAlive = false;
        GameObject.FindWithTag("EnemyManager").GetComponent<EnemyManager>().SetEnemyManagerSO(ID, false);
            return 0;
    }


   
}