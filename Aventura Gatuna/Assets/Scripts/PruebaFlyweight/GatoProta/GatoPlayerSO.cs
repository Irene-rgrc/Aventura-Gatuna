using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAttributes", menuName = "PlayerData", order = 1)]
public class GatoPlayerSO : ScriptableObject
{
    public int gato;
    public int maxLife;
    public int minMoney;
}
