using Command.Interfaces;
using TMPro;
using UnityEngine;

namespace Command.Commands
{
    public class Bribe5 : ICommand
    {
        private IGameController gameController;
        public TMP_Text bribe;

        public Bribe5(IGameController receiver, TMP_Text bribe)
        {
            this.gameController = receiver;
            this.bribe = bribe;
        }

        public void Execute()
        {
            gameController.SetEnemyProb(gameController.GetEnemyProb() - 5);
            gameController.SetMoneySpent(gameController.GetMoneySpent() + 500);
            bribe.text = "Soborno:\r\n\t" + gameController.GetEnemyProb() + "%\r\n\t" + gameController.GetMoneySpent() + " monedas";
        }

        public void Undo()
        {
            gameController.SetEnemyProb(gameController.GetEnemyProb() + 5);
            gameController.SetMoneySpent(gameController.GetMoneySpent() - 500);
            bribe.text = "Soborno:\r\n\t" + gameController.GetEnemyProb() + "%\r\n\t" + gameController.GetMoneySpent() + " monedas";
        }
    }
}