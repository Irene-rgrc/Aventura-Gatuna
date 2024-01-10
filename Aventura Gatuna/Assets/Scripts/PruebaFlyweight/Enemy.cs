using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Assertions;

[System.Serializable]
public class Enemy : MonoBehaviour
{
    public EnemyAttributes Attributes;
    public int life;
    public int probability;

    private void Awake()
    {
        Assert.IsNotNull(Attributes);
        Debug.Log($"{Attributes.enemyType} created. Life: {Attributes.maxLife}, Probability: {Attributes.maxProbability} ");
        life = Attributes.maxLife; probability = Attributes.maxProbability;
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
        return Attributes.maxLife;
    }

    public int SetProbability(int newProbability)
    {
        Attributes.maxProbability = newProbability;
        return Attributes.maxProbability;
    }

    public int Damage() {
        if (Attributes.maxLife > 25) //cada vez que el enemigo pierda en un minijuego se le va a quitar 25 puntos de su vida
        {
            SetHealth(Attributes.maxLife - 25);
        }
        else
        {
            SetHealth(0);
        }
        return Attributes.maxLife;
    }

    public bool isAlive()
    {
        if(GetHealth() == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
       
    }

    public void EnemyDeath()
    {
        gameObject.SetActive(false);
    }

   
}