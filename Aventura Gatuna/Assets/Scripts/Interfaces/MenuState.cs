using UnityEngine;

namespace Patterns.State.Interfaces
{
    public abstract class MenuState : IState
    {
        protected IMenu menu ;

        public MenuState(IMenu menu)
        {
            this.menu = menu;
        }

        public abstract void Enter();
        public abstract void Exit();
        public abstract void Update();
        public abstract void FixedUpdate();
    }
}