using GameSystem.FightSystem.Buff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.FightSystem.Buff
{ 

    public interface IBuffable
    { 
        void AddBuff(BaseBuff buff);
        void RemoveBuff(BaseBuff buff);
    }
}
