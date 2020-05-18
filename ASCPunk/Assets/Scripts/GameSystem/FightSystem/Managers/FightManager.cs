using FrameWork;
using GameSystem.FightSystem.CommonInterface;
using GameSystem.FightSystem.Enemy;
using GameSystem.FightSystem.Tower;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace GameSystem.FightSystem.Managers
{
    public enum CurRoundState
    {
        Self,
        Enemy,
    }

    public enum FinishState
    {
        Fail,
        Success,
        Continue,
    }
    public class FightManager : MonoSingletion<FightManager>
    {
        private static CurRoundState curRoundState;

        private List<BaseEnemy> enemyList;
        private List<BaseTower> towerList;
        private OperationModule selfModule;
        private OperationModule enemyModule;

        public static CurRoundState CurRound { get => curRoundState; }
       
        public void Init(string configure, string enemy)
        {
            MessageCenter.Instance.AddListener("ShiteRound", (Message message) =>
            {
                curRoundState = (CurRoundState)message["state"];
            });
            selfModule = new PlayerRoundModule();
            enemyModule = GetEnemyModule("enemy");
        }

        private OperationModule GetEnemyModule(string module)
        {
            if (module.Equals("enemy"))
            {
                return new EnemyAIModule(enemyList);
            }
            return new PlayerRoundModule();
        }

        public void FightLoop()
        {
            SelfRound();
            switch (CheckFinish())
            {
                case FinishState.Success:
                    FightSuccess();
                    break;
                case FinishState.Fail:
                    FightFail();
                    break;
            }

            EnemyRound();
            switch (CheckFinish())
            {
                case FinishState.Success:
                    FightSuccess();
                    break;
                case FinishState.Fail:
                    FightFail();
                    break;
            }
        }

        private FinishState CheckFinish()
        {
            if (CheckEnemyFinishCondition() == FinishState.Success)
            {
                return FinishState.Success;
            }

            switch (CheckGateFinishCondition())
            {
                case FinishState.Continue:
                    break;
                case FinishState.Fail:
                    return FinishState.Fail;
                case FinishState.Success:
                    return FinishState.Success;
            }

            return CheckSelfFinishCondition();
        }

        protected virtual FinishState CheckSelfFinishCondition()
        {
            foreach (var i in towerList)
            {
                if (i.IsAlive)
                {
                    return FinishState.Continue;
                }
            }
            return FinishState.Fail;
        }

        protected virtual FinishState CheckEnemyFinishCondition()
        {
            foreach (var i in enemyList)
            {
                if (i.IsAlive)
                {
                    return FinishState.Continue;
                }
            }
            return FinishState.Success;
        }

        protected virtual FinishState CheckGateFinishCondition()
        {
            return FinishState.Continue;
        }

        private void SelfRound()
        {
            curRoundState = CurRoundState.Self;
            selfModule.ExecuteRound();
        }

        private void EnemyRound()
        {
            curRoundState = CurRoundState.Enemy;
            enemyModule.ExecuteRound();
        }

        private void FightFail()
        {

        }

        private void FightSuccess()
        {

        }

        protected override void Init()
        {
            throw new NotImplementedException();
        }
    }

}
