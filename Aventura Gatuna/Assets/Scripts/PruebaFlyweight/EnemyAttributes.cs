using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAttributes", menuName = "EnemyData", order = 1)]
public class EnemyAttributes : ScriptableObject
{
    public string enemyType; //Varible para asignarle un nombre o tipo a cada enemigo, simplemente es "visual" no se usa para nada dentro de los scripts, meramente organizativo y estético
    public int maxLife;
    public int maxProbability;

}