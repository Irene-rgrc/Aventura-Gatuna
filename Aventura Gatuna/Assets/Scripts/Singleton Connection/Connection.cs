using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class Connection : ASingleton<Connection>
{
    private int probability;
    private int money;
    private bool win;
    private bool coinWin;
    private GameObject enemy;
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
    public void SetWin(bool win)
    {
        this.win = win;
    }
    public bool GetWin()
    {
        return win;
    }
    public void SetCoinWin(bool win)
    {
        this.coinWin = win;
    }
    public bool GetCoinWin()
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
    public void SetEnemy(GameObject enemy)
    {
        this.enemy = enemy;
    }
    public GameObject GetEnemy()
    {
        return enemy;
    }
}
