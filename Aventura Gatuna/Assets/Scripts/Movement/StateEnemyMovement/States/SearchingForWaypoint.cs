using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemyState.Interfaces;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;
using Transform = UnityEngine.Transform;

public class SearchingForWaypoint : AMovementState
{
    private Transform currentTransform;
    private Transform nextWaypoint;
    private Transform currentWaypoint;

    public SearchingForWaypoint(IEnemyMovement enemy) : base(enemy)
    {
    }

    public override void Enter()
    {
        Transform[] waypoints = enemy.GetWayPoints();
        int nextWayPointIndex = (Array.IndexOf(waypoints, enemy.GetCurrentWaypoint()) + 1);
        if (nextWayPointIndex > waypoints.Length-1) { nextWayPointIndex = 0; }
        nextWaypoint = waypoints[nextWayPointIndex];
        enemy.SetCurrentWayPoint(nextWaypoint);
        currentTransform = enemy.GetGameObject().transform;
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
    }

    public override void FixedUpdate()
    {
            enemy.SetState(new Walking(enemy));
    }
}
