using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public class Chasing : IMovementState
{
    private Transform targetTransform;
    private Transform currentTransform;

    //private float rotationSpeed;
    private float chaseSpeed;

    public Chasing(IEnemyMovement enemy) : base(enemy)
    {
    }

    public override void Enter()
    {
        currentTransform = enemy.GetGameObject().transform;
        //playerTransform = enemy.PlayerAtSight().transform;
        //rotationSpeed = enemy.GetRotateSpeed();
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
        /*if (enemy.PlayerAtSight())
        {
            enemy.MoveTo(targetTransform, chaseSpeed);
        }
        else*/
        {
            enemy.SetState(new Walking(enemy));
        }
    }
}
