using GameSystem.FightSystem.Buff;
using GameSystem.FightSystem.CommonInterface;
using GameSystem.FightSystem.Enemy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace GameSystem.FightSystem.Tower
{
    public abstract class BaseTower : Character
    {
        public TowerInfo towerInfo;
        protected AnimatorFSM animator;
        private void Awake()
        {
            animator = new AnimatorFSM(GetComponent<Animator>());

        }


    }
}
