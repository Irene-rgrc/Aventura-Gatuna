using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "EnemyManager", menuName = "Enemy Manager", order = 1)]
public class EnemyManagerSO : ScriptableObject
{
    public bool[] enemyStates = new bool[6];

    public void Initialize(int numberOfEnemyTypes)
    {
        if (enemyStates == null) {
            enemyStates = new bool[numberOfEnemyTypes];
        }
    }

    public void SetEnemyState(int enemyType, bool isAlive)
    {
        if (enemyType >= 0 && enemyType < enemyStates.Length)
        {
            enemyStates[enemyType] = isAlive;
        }
        else
        {
            Debug.LogError("Invalid enemy type: " + enemyType);
        }
    }

    public bool GetEnemyState(int enemyType)
    {
        if (enemyType >= 0 && enemyType < enemyStates.Length)
        {
            return enemyStates[enemyType];
        }
        else
        {
            Debug.LogError("Invalid enemy type: " + enemyType);
            return false; 
        }
    }
}