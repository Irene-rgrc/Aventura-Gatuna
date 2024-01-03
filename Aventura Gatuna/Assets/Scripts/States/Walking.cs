using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.Apple;
using Interfaces;

public class Walking : IMovementState
{
    private Transform currentWaypoint;
    private Transform currentTransform;
    private float speed;
    private float range;
    private float minDistance = 1.0f;

    private float secondsToSeek = 1f;
    private float lastSeek = 0f;

    public override void Enter()
    {
        currentTransform = enemy.GetGameObject().transform;
        currentWaypoint = enemy.GetCurrentWaypoint();
        speed = enemy.GetWanderSpeed();

        enemy.SetCurrentSpeed(speed);
    }

    public Walking(IEnemyMovement enemy) : base(enemy)
    {
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        /*lastSeek += Time.deltaTime;

        if (lastSeek >= secondsToSeek)
        {
            enemy.SetState(new SearchingForPlayer(enemy));
            lastSeek = 0f;
        }*/

    }

    public override void FixedUpdate()
    {
        enemy.MoveTo(currentWaypoint, speed);
        Debug.Log($"fddgffdgs");
        range = Vector2.Distance(currentTransform.position, currentWaypoint.position);
        if (range < minDistance)
        {
            enemy.SetState(new SearchingForWaypoint(enemy));
        }
    }
}
