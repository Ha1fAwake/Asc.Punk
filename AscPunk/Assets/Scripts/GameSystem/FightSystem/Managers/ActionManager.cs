using FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.FightSystem.Managers
{
    public class ActionManager : MonoSingletion<ActionManager>
    {
        /// <summary>
        /// 所有每帧调用持续性的Action事件字典
        /// </summary>
        private Dictionary<string, Action[]> frameContinuousActionDic;

        /// <summary>
        /// 每回合调用的事件字典
        /// </summary>
        private Dictionary<string, Action[]> roundContinuousActionDic;

        /// <summary>
        /// 所有回合延迟事件
        /// </summary>
        private Dictionary<int, Action[]> roundTimerEventDic;

        protected override void Init()
        {
            frameContinuousActionDic = new Dictionary<string, Action[]>();
            roundTimerEventDic = new Dictionary<int, Action[]>();
            roundContinuousActionDic = new Dictionary<string, Action[]>();
        }

        /// <summary>
        /// 注册按帧计算的Action延迟事件
        /// </summary>
        /// <param name="action"></param>
        /// <param name="timer"></param>
        public void AddActionFrameTimerEvent(float timer, params Action[] actions)
        {
            StartCoroutine(FrameLaterAction(actions, timer));
        }

        /// <summary>
        /// 注册按回合计算的Action延迟事件
        /// </summary>
        /// <param name="action"></param>
        /// <param name="timer"></param>
        public void AddActionRoundTimerEvent(int timer, params Action[] actions)
        {
            //StartCoroutine(FrameLaterAction(action, timer));
        }

        /// <summary>
        /// 注册每帧调用的事件
        /// </summary>
        /// <param name="ActionName"></param>
        /// <param name="actions"></param>
        public void AddFrameContinuousActionEvent(string ActionName, params Action[] actions)
        {
            frameContinuousActionDic.Add(ActionName, actions);
        }

        /// <summary>
        /// 移除每帧调用的事件
        /// </summary>
        /// <param name="ActionName"></param>
        public void RemoveFrameContinuousActionEvent(string ActionName)
        {
            if(frameContinuousActionDic.ContainsKey(ActionName))
            {
                frameContinuousActionDic.Remove(ActionName);
            }
        }

        /// <summary>
        /// 注册每回合调用的事件
        /// </summary>
        /// <param name="ActionName"></param>
        /// <param name="actions"></param>
        public void AddRroundContinuousActionEvent(string ActionName, params Action[] actions)
        {
            roundContinuousActionDic.Add(ActionName, actions);
        }

        /// <summary>
        /// 移除每回合调用的事件
        /// </summary>
        /// <param name="ActionName"></param>
        public void RemoveRoundContinuousActionEvent(string ActionName)
        {
            if (roundContinuousActionDic.ContainsKey(ActionName))
            {
                roundContinuousActionDic.Remove(ActionName);
            }
        }

        /// <summary>
        /// 每个逻辑帧更新所有Action的效果
        /// </summary>
        private void FixedUpdate()
        {
            foreach(var ActionList in frameContinuousActionDic)
            {
                foreach(var Action in ActionList.Value)
                {
                    Action();
                }
            }
        }

        /// <summary>
        /// 每个回合执行所有action
        /// </summary>
        public void RoundUpdate()
        {
            foreach (var ActionList in roundContinuousActionDic)
            {
                foreach (var Action in ActionList.Value)
                {
                    Action();
                }
            }
            List<int> list = new List<int>();
            list.AddRange(roundTimerEventDic.Keys);
            foreach(var i in list)
            {
                var actions = roundTimerEventDic[i];
                int timer = i;
                roundTimerEventDic.Remove(i);
                timer--;
                if(timer == 0)
                {
                    foreach(var action in actions)
                    {
                        action();
                    }
                }
                else
                {
                    roundTimerEventDic.Add(timer, actions);
                }
            }
        }

        /// <summary>
        /// 通过协程延迟执行action
        /// </summary>
        /// <param name="action"></param>
        /// <param name="timer"></param>
        /// <returns></returns>
        private IEnumerator<int> FrameLaterAction(Action[] actions, float timer)
        {
            float time = 0f;
            while(time < timer)
            {
                yield return 0;
            }
            foreach(var action in actions)
            {
                action();
            }
            yield break;
        }


    }
}
