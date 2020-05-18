using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.FightSystem.Skill
{
    public interface IUseSkillable
    {
        void LearnSkill(int index);

        void UpgradeSkills(int index);

        void UseSkill(int index);

        SkillInfo GetSkillInfo(int index);

        int SkillCount { get; }

        int SkillLevel(int index);

        int SkillCold(int index);

        int Mana { get;}
    }
}
