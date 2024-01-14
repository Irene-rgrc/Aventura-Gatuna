using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAttributes", menuName = "EnemyData", order = 1)]
public class EnemyAttributes : ScriptableObject
{
    public int enemyType; 
    public int maxLife;
    public int maxProbability;

}