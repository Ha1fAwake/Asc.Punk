using FrameWork.Command;
using GameSystem.FightSystem;
using GameSystem.FightSystem.CommonInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.CommondSystem
{
    public class AttackCommond : BaseCommand
    {
        Damageable damageable;

        public AttackCommond(Damageable damageable)
        {
            this.damageable = damageable;
        }

        public override void Execute(IReceiver receiver)
        {
            var chararcter = receiver as Character;
            chararcter.AttackEnemy(damageable);
        }
    }
}
