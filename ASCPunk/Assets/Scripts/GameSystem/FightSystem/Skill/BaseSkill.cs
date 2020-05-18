using GameSystem.FightSystem.CommonInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.FightSystem.Skill
{
    public abstract class BaseSkill
    {
        private SkillInfo info;
        private int level;
        private int curCold;
        public SkillInfo Info { get => info;}
        public int Level { get => level;}
        public int CurCold { get => curCold;}

        public abstract void Use(Character user);

        public abstract void OnLearnSkill();

        public abstract void OnSkillLevelUp();

    }
}
