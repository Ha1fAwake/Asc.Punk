using GameSystem.FightSystem.CommonInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.FightSystem.Enemy
{
    public class EnemyAIModule : OperationModule
    {
        private List<BaseEnemy> enemyList;
        public override void ExecuteRound()
        {
        }

        public EnemyAIModule(List<BaseEnemy> enemyList):base()
        {
            this.enemyList = enemyList;
        }



        private void Action(BaseEnemy enemy)
        {

        }

    }
}
