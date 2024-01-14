using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private EnemyManagerSO enemyManager;

    // Diccionario para almacenar la relación entre IDs únicos de enemigos y sus estados de vida
    private Dictionary<int, bool> enemyIDStates = new Dictionary<int, bool>();
    public void SetEnemyManagerSO(int enemy, bool isAlive)
    {
        enemyManager.SetEnemyState(enemy, isAlive);
    }
    public bool GetEnemyManagerSO(int enemy)
    {
        return enemyManager.GetEnemyState(enemy);
    }
    void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name != "MainMenu")
        {
            // Inicializa el EnemyManagerSO
            //enemyManager.Initialize(6);

            Invoke("HandleEnemies", 2.0f);
        }

        //if (Connection.Instance.GetEnemy() != null) { }
    }

    void HandleEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Scene currentScene = SceneManager.GetActiveScene();

        int i=0;
        foreach (GameObject enemy in enemies)
        {
           
            Enemy enemyComponent = enemy.GetComponent<Enemy>();
           
            if (enemyComponent != null)
            {
                

                int enemyID = enemy.GetInstanceID();
                enemyComponent.SetID(i);
                i++;
               
                if (enemyIDStates.ContainsKey(enemyID))
                {
                    
                    bool isAlive = enemyIDStates[enemyID];
                    enemyComponent.isAlive = isAlive;
                }
                else
                {
                    
                    enemyComponent.isAlive = true;
                }

               
                bool isAliveNow = enemyComponent.isAlive;

              
                enemyIDStates[enemyID] = isAliveNow;

                
                if (!isAliveNow)
                {
                    enemyComponent.MarkAsDead();
                    enemy.gameObject.SetActive(false);
                    
                }
            }
            PrintEnemyStates();
        }


        bool allEnemiesDead = AreAllEnemiesDead();

        if (allEnemiesDead && currentScene.name != "MainMenu")
        {
            SceneManager.LoadScene("CoinFlip");

        }
    }

    private bool AreAllEnemiesDead()
    { 
        foreach (bool isAlive in enemyManager.enemyStates)
        {
            if (isAlive)
            {
                return false; // Hay al menos un enemigo vivo
            }
        }

        return true; // Todos los enemigos están muertos
    }

    private void PrintEnemyStates()
    {
        // Imprime el estado de cada enemigo en la consola
        foreach (KeyValuePair<int, bool> entry in enemyIDStates)
        {
            //Debug.Log($"EnemyID {entry.Key}: {entry.Value}");
        }
    }

}