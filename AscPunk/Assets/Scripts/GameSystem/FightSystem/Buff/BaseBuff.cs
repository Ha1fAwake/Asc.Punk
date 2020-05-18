using GameSystem.FightSystem.CommonInterface;
using GameSystem.FightSystem.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.FightSystem.Buff
{
   
    public abstract class BaseBuff
    {
        private BuffData buffData;
        private Character character;
        /// <summary>
        /// 为对象添加buff效果，同时把
        /// </summary>
        /// <param name="character"></param>
        public void StartBuff(Character character)
        {
            this.character = character;
            character.AddBuff(this);
            DoBuff();
            AddBuffEvent();
        }
        /// <summary>
        /// 开始buff效果
        /// </summary>
        protected abstract void DoBuff();

        /// <summary>
        /// buff结束事件,当buff被添加时自动注册
        /// </summary>
        protected virtual void EndBuff()
        {
            ActionManager.Instance.RemoveFrameContinuousActionEvent(buffData.BuffName);
        }

        /// <summary>
        /// 注册所有延迟buff事件
        /// </summary>
        protected virtual void AddBuffEvent()
        {
            AddBuffEndEvent(buffData.Duration);
        }
        /// <summary>
        /// 注册buff结束事件，time = -1时表示为永久buff
        /// </summary>
        /// <param name="time"></param>
        protected void AddBuffEndEvent(int timer)
        {
            if (timer < 0)
                return;
            ActionManager.Instance.AddActionRoundTimerEvent(timer,EndBuff);
        }
    }
}
