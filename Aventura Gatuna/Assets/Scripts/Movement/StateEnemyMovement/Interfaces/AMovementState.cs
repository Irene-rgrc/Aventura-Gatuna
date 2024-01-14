using UnityEngine;

namespace EnemyState.Interfaces
{
    public abstract class AMovementState : IState
    {
        protected IEnemyMovement enemy;

        public AMovementState(IEnemyMovement enemy)
        {
            this.enemy = enemy;
        }

        public abstract void Enter();
        public abstract void Exit();
        public abstract void Update();
        public abstract void FixedUpdate();
    }
}
