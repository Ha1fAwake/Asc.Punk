using GameSystem.FightSystem.Buff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace GameSystem.FightSystem.CommonInterface
{
    public class Damager 
    {
        private int aggressivity;
        private Animator animator;
        private Action<Damageable> beforeAttackEvents;
        private Action<Damageable> onAttackEvents;
        private Action<Damageable> afterAttackEvents;
        private List<BaseBuff> buffs;

        public int Aggressivity { get => aggressivity; set => aggressivity = value; }
        public Damager()
        {
            onAttackEvents += Attack;
        }

        public void AddBeforeAttackEvent(Action<Damageable> handler)
        {
            beforeAttackEvents += handler;
        }

        public void RemoveBeforeAttackEvent(Action<Damageable> handler)
        {
            beforeAttackEvents -= handler;
        }

        public void AddOnAttackEvent(Action<Damageable> handler)
        {
            onAttackEvents += handler;
        }

        public void RemoveOnAttackEvent(Action<Damageable> handler)
        {
            onAttackEvents -= handler;
        }

        public void AddAfterAttackEvent(Action<Damageable> handler)
        {
            afterAttackEvents += handler;
        }

        public void RemoveAfterAttackEvent(Action<Damageable> handler)
        {
            afterAttackEvents -= handler;
        }

        public void OnAttack(Damageable enemy)
        {
            beforeAttackEvents(enemy);
            onAttackEvents(enemy);
            afterAttackEvents(enemy);
        }
       
        private void Attack(Damageable enemy)
        {
            enemy.OnUnderAttack(this);
        }

    }
}
