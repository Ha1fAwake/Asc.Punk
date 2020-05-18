using FrameWork.Command;
using GameSystem.FightSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommondSystem
{
    public class UseSkillCommond : BaseCommand
    {
        int skillIndex;

        public UseSkillCommond(int skillIndex)
        {
            this.skillIndex = skillIndex;
        }

        public override void Execute(IReceiver receiver)
        {
            var character = receiver as Character;
            character.UseSkill(skillIndex);
        }
    }
}
