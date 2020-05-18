using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Command;
using GameSystem.FightSystem;
using UnityEngine;
namespace GameSystem.CommondSystem
{
    class MoveCommond : BaseCommand
    {
        Vector2 pos;

        public MoveCommond(Vector2 pos)
        {
            this.pos = pos;
        }

        public override void Execute(IReceiver receiver)
        {
            var chararcter = receiver as Character;
            chararcter.Move(pos);
        }
    }
}
