using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

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
        /*if (enemy.PlayerAtSight() != null)
        {
            enemy.SetState(new Chasing(enemy));
        }
        else*/
        {
            enemy.SetState(new Walking(enemy));
        }
    }

    public override void FixedUpdate()
    {
    }
}
