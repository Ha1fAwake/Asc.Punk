using GameSystem.FightSystem.Buff;
using GameSystem.FightSystem.CommonInterface;
using GameSystem.FightSystem.Skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using FrameWork.Command;
namespace GameSystem.FightSystem
{
    public enum CharacterType
    {
        Self,
        Enemy,
        NPC,
    }
    public abstract class Character : MonoBehaviour, IBuffable,IMoveable, IUseSkillable,IReceiver
    {
        protected Damager damager;
        protected Damageable damageable;
        protected List<BaseBuff> buffList;
        protected CharacterType type;
        protected Vector2 position;
        protected Vector2 direction;
        protected AnimatorFSM animator;
        protected List<BaseSkill> skillList;
        protected bool isAlive;
        protected int movingForce;
        protected int mana;

        public Vector2 Position { get => position; }
        public Vector2 Direction { get => direction; }
        public int SkillCount { get => skillList.Count; }
        public bool IsAlive { get => isAlive;}
        public int MovingForce { get => movingForce; }
        public int Mana { get => mana; protected set => mana = value; }

        public void AttackEnemy(Damageable enemy)
        {
            damager.OnAttack(enemy);
        }

        public virtual Character[] GetEnemiesInRange()
        {
            return null;
        }

        public void AddBuff(BaseBuff buff)
        {
            buffList.Add(buff);
        }

        public void RemoveBuff(BaseBuff buff)
        {
            buffList.Remove(buff);
        }

        public void Move(Vector2 target)
        {
            var dir = target - Position;
            if(dir.normalized.Equals(Direction))
            {
                MoveTo(target);
            }
            else
            {
                TurnTo(dir);
                MoveTo(target);
            }
        }

        private void MoveTo(Vector2 target)
        {

        }

        private void TurnTo(Vector2 target)
        {

        }

        public void LearnSkill(int index)
        {
            skillList[index].OnLearnSkill();
            skillList[index].OnSkillLevelUp();
        }

        public void UpgradeSkills(int index)
        {
            skillList[index].OnSkillLevelUp();
        }

        public void UseSkill(int index)
        {
            try
            {
                skillList[index].Use(this);
            }
            catch
            {

            }
        }

        public SkillInfo GetSkillInfo(int index)
        {
            return skillList[index].Info;
        }

        public int SkillLevel(int index)
        {
            return skillList[index].Level;
        }

        public int SkillCold(int index)
        {
            return skillList[index].CurCold;
        }
    }
}
