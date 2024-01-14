using UnityEngine;

namespace EnemyState.Interfaces
{
    public interface IEnemyMovement
    {
        public GameObject GetGameObject();
        public void SetState(IState state);
        public IState GetState();
        public float GetWanderSpeed();
        public float GetChaseSpeed();
        public void MoveTo(Transform target, float speed);
        public Transform[] GetWayPoints();
        public Transform GetCurrentWaypoint();
        public void SetCurrentWayPoint(Transform target);
        public GameObject GetPlayerAtSight();
        public void SetPlayerAtSight(GameObject playerAtSight);
    }
}
