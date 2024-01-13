using Command.Interfaces;
using TMPro;
using UnityEngine;

namespace Command.Commands
{
    public class Bribe5 : ICommand
    {
        private GameplayController gameController;
        public TMP_Text bribe;

        public Bribe5(GameplayController receiver, TMP_Text bribe)
        {
            this.gameController = receiver;
            this.bribe = bribe;
        }

        public void Execute()
        {
            gameController.SetEnemyProb(gameController.GetEnemyProb() - 5);
            gameController.SetMoney(gameController.GetMoney() - 500);
            bribe.text = "Soborno:\r\n\tProbabilidad del enemigo:" + gameController.GetEnemyProb() + "%\r\n\tTienes:" + gameController.GetMoney() + " monedas";
        }

        public void Undo()
        {
            gameController.SetEnemyProb(gameController.GetEnemyProb() + 5);
            gameController.SetMoney(gameController.GetMoney() + 500);
            bribe.text = "Soborno:\r\n\tProbabilidad del enemigo:" + gameController.GetEnemyProb() + "%\r\n\tTienes:" + gameController.GetMoney() + " monedas";
        }
    }
}