using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.FightSystem.CommonInterface
{
    public interface IFSM
    {
        int StateNumber { get; }
        string CurrentState { get; }
        void SetState(string stateName);
    }
}
