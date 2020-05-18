using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.FightSystem.CommonInterface
{
    public class Damageable
    {
        private int defense;
        private int health;
        private Action<Damager> beforeUnderAttackEvents;
        private Action<Damager> onUnderAttackEvents;
        private Action<Damager> afterUnderAttackEvents;

        public int Defense { get => defense;}
        public int Health { get => health;}

        public Damageable()
        {
            onUnderAttackEvents += UnderAttack;
        }

        public void AddBeforeUnderAttackEvent(Action<Damager> handler)
        {
            beforeUnderAttackEvents += handler;
        }

        public void RemoveBeforeUnderAttackEvent(Action<Damager> handler)
        {
            beforeUnderAttackEvents -= handler;
        }

        public void AddOnUnderAttackEvent(Action<Damager> handler)
        {
            onUnderAttackEvents += handler;
        }

        public void RemoveOnUnderAttackEvent(Action<Damager> handler)
        {
            onUnderAttackEvents -= handler;
        }

        public void AddAfterUnderAttackEvent(Action<Damager> handler)
        {
            afterUnderAttackEvents += handler;
        }

        public void RemoveUnderAfterAttackEvent(Action<Damager> handler)
        {
            afterUnderAttackEvents -= handler;
        }

        public void OnUnderAttack(Damager damager)
        {
            beforeUnderAttackEvents(damager);
            OnUnderAttack(damager);
            afterUnderAttackEvents(damager);
        }

        private void UnderAttack(Damager damager)
        {
            health -= Math.Abs(damager.Aggressivity - defense);
            if(health <= 0)
            {
                Die();
            }
            else
            {

            }
        }

        public void Die()
        {

        }

    }
}
