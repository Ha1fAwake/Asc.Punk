using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace GameSystem.FightSystem.CommonInterface
{
    public class AnimatorFSM : IFSM
    {
        private Animator animator;
        private int statrNumber;
        private string currentState;
        private const string attackState = "attack";
        private const string idleState = "idle";
        private const string moveState = "move";

        public AnimatorFSM(Animator animator)
        {
            this.animator = animator;
            statrNumber = animator.GetCurrentAnimatorClipInfoCount(0);
            currentState = idleState;
        }

        public int StateNumber => statrNumber;

        public string CurrentState => animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;

        public void Attack()
        {
            FSM(attackState);
        }

        public void SetState(string stateName)
        {
            FSM(stateName);
        }

        protected virtual void FSM(string stateName)
        {
            switch (currentState)
            {
                case idleState:
                    if (stateName.Equals(attackState))
                    {
                        animator.SetBool(attackState, true);
                        currentState = attackState;
                    }
                    if (stateName.Equals(moveState))
                    {
                        animator.SetBool(moveState, true);
                        currentState = moveState;
                    }
                    break;
            }
        }
    }
}
