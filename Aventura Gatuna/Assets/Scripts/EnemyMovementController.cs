using Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using System.Transactions;
using Interfaces;
//using States;
using Unity.VisualScripting;
using IState = Interfaces.IState;
using static UnityEngine.GraphicsBuffer;
using System;

public class EnemyMovementController : MonoBehaviour, IEnemyMovement
{
    private float range;
    private float minDistance = 5.0f;
    private bool targetCollision = false;
    public float WanderSpeed;
    public float ChaseSpeed;

    private IState currentState;

    public Transform currentWaypoint;
    public Transform[] waypoints;

    private void Awake()
    {
        Assert.IsTrue(waypoints.Length > 0, "Waypoints must be greater than 1");
        if (currentWaypoint == null)
        {
            currentWaypoint = waypoints[0];
        }

        //animator = gameObject.GetComponent<Animator>();

        SetState(new Walking(this));
        Debug.Log($"asdsdasdffd");
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    #region Get & Set speeds

    public float GetWanderSpeed()
    {
        return WanderSpeed;
    }

    public float GetChaseSpeed()
    {
        return ChaseSpeed;
    }

    public void SetCurrentSpeed(float speed)
    {
        //animator.SetFloat("MoveSpeed", speed);
    }
    #endregion

    #region Get & set Waypoints
    public Transform[] GetWayPoints()
    {
        return waypoints;
    }

    public Transform GetCurrentWaypoint()
    {
        return currentWaypoint;
    }

    public void SetCurrentWayPoint(Transform currentWaypoint)
    {
        this.currentWaypoint = currentWaypoint;
    }
    #endregion

    #region Set y Get State, state pattern
    public IState GetState()
    {
        return currentState;
    }

    public void SetState(IState state)
    {
        // Exit old state
        if (currentState != null)
        {
            currentState.Exit();
        }

        // Set current state and enter
        currentState = state;
        currentState.Enter();
    }
    #endregion

    private void Update()
    {
        currentState.Update();
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdate();
    }

    public void MoveTo(Transform target, float speed)
    {
        range = Vector2.Distance(transform.position, target.position);
        //if (range < minDistance)
        {
            if (!targetCollision)
            {
                // Get the position of the player
                transform.LookAt(target.position);
                Debug.Log($"sdfgsdg");
                // Correct the rotation
                transform.Rotate(new Vector3(0, -90, 0), Space.Self);
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            }
        }
        transform.rotation = Quaternion.identity;
    }

}
