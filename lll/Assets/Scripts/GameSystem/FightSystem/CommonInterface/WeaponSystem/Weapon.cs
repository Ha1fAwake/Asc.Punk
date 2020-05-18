using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.FightSystem.CommonInterface.WeaponSystem
{
    public abstract  class Weapon
    {
        WeaponInfo info;
        Damager holder;
        
        public Weapon(WeaponInfo info, Damager holder)
        {
            this.info = info;
            this.holder = holder;
            holder.AddBeforeAttackEvent(OnBeforeAttack);
            holder.AddOnAttackEvent(OnAttack);
            holder.AddAfterAttackEvent(OnAfterAttack);
        }

        protected abstract void OnBeforeAttack(Damageable enemy);
        protected virtual void OnAttack(Damageable enemy)
        {

        }
        protected abstract void OnAfterAttack(Damageable enemy);

    }
}
