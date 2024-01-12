using UnityEngine;

namespace Patterns.State.Interfaces
{
    public interface IMenu
    {
        public GameObject GetGameObject();
        public void SetState(IState state);
        public IState GetState();

    }
}