using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.FightSystem.Buff
{
    public enum BuffType
    {

    }
    public class BuffData
    {
        private string buffName;
        private string buffDescription;
        private BuffType type;
        private int buffLayer;
        private bool isSuperposition;
        private int maxSuperpositionNumber;
        private int duration;

        /// <summary>
        /// buff持续时间，负数表示永久
        /// </summary>
        public int Duration { get => duration; set => duration = value; }
        public string BuffName { get => buffName; set => buffName = value; }
    }
}
