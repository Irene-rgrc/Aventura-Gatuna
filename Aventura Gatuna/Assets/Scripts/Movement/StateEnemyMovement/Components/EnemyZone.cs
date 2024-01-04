using EnemyState.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZone : MonoBehaviour
{
    public GameObject enemy;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"playerplayer");
            enemy.GetComponent<EnemyMovementController>().SetPlayerAtSight(other.gameObject);
        }
        Debug.Log($"nonono");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.GetComponent<EnemyMovementController>().SetPlayerAtSight(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.GetComponent<EnemyMovementController>().SetPlayerAtSight(null);
        }
    }
}
