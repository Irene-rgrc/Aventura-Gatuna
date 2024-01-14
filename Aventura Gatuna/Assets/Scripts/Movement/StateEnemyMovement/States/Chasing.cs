using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemyState.Interfaces;

public class Chasing : AMovementState
{
    private Transform playerTransform;
    private float chaseSpeed;

    public Chasing(IEnemyMovement enemy) : base(enemy)
    {
    }

    public override void Enter()
    {
        playerTransform = enemy.GetPlayerAtSight().transform;
        chaseSpeed = enemy.GetChaseSpeed();
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
    }

    public override void FixedUpdate()
    {
        if (enemy.GetPlayerAtSight())
        {
            enemy.MoveTo(playerTransform, chaseSpeed);
        }
        else
        {
            enemy.SetState(new Walking(enemy));
        }
    }
}
