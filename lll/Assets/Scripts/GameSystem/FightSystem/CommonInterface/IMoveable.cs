using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GameSystem.FightSystem.CommonInterface
{
    public interface IMoveable
    {
        UnityEngine.Vector2 Position { get; }
        UnityEngine.Vector2 Direction { get; }
        void Move(UnityEngine.Vector2 target);
        int MovingForce { get; }
    }
}
