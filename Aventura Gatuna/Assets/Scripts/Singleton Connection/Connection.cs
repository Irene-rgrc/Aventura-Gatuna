using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class Connection : ASingleton<Connection>
{
    private int probability;
    private int money;
    private int playerLife;
    private int enemyLife;
    private int win = 3;
    private int coinWin = 3;
    private int enemy;
    public Vector3 playerPosition;
    private bool isPlaying;
    public void SetProbability(int probability)
    {
        this.probability = probability;
    }
    public int GetProbability()
    {
        return probability;
    }
    public void SetMoney(int money)
    {
        this.money = money;
    }
    public int GetMoney()
    {
        return money;
    }

    public void SetLife(int newplayerLife)
    {
        this.playerLife = newplayerLife;
    }
    public int GetLife()
    {
        return playerLife;
    }

    public void SetEnemyLife(int newenemyLife)
    {
        this.enemyLife = newenemyLife;
    }
    public int GetEnemyLife()
    {
        return enemyLife;
    }

    public void SetWin(int win)
    {
        this.win = win;
    }
    public int GetWin()
    {
        return win;
    }
    public void SetCoinWin(int win)
    {
        this.coinWin = win;
    }
    public int GetCoinWin()
    {
        return coinWin;
    }
    public void SetPosition(Vector3 position)
    {
        playerPosition = position;
    }
    public Vector3 GetPosition()
    {
        return playerPosition;
    }
    public void SetIsPlaying(bool isPlaying)
    {
        this.isPlaying = isPlaying;
    }
    public bool GetIsPlaying()
    {
        return isPlaying;
    }
    public void SetEnemy(int enemy)
    {
        this.enemy = enemy;
    }
    public int GetEnemy()
    {
        return enemy;
    }
}
