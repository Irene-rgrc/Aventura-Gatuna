using UnityEngine;

namespace Interfaces
{
    public abstract class IMovementState : IState
    {
        protected IEnemyMovement enemy;

        public IMovementState(IEnemyMovement enemy)
        {
            this.enemy = enemy;
        }

        public abstract void Enter();
        public abstract void Exit();
        public abstract void Update();
        public abstract void FixedUpdate();
    }
}
