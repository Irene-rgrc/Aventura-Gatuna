using UnityEngine;

namespace Command.Interfaces
{
    public interface IGameController
    {
        public void SetEnemyProb(int enemy_prob);
        public int GetEnemyProb();

        public void SetMoney(int money);
        public int GetMoney();
    }
}