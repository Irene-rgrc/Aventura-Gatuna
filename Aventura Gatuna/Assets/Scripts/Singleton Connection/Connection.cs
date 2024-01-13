using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class Connection : ASingleton<Connection>
{
    private int probability;
    private int money;
    private bool win;
    private GameObject enemy;
    private Vector3 playerPosition;
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
    public void SetPosition(Vector3 position)
    {
        playerPosition = position;
    }
    public Vector3 GetPosition()
    {
        return playerPosition;
    }
}
