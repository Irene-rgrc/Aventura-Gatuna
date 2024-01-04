using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemyState.Interfaces;

public class SearchingForPlayer : IMovementState
{
    public SearchingForPlayer(IEnemyMovement enemy) : base(enemy)
    {
    }

    public override void Enter()
    {
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        if (enemy.GetPlayerAtSight() != null)
        {
            Debug.Log($"sdfgsdg");
            enemy.SetState(new Chasing(enemy));
        }
        else
        {
            Debug.Log($"nanana");
            enemy.SetState(new Walking(enemy));
        }
    }

    public override void FixedUpdate()
    {
    }
}
