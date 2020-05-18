using GameSystem.FightSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace GameSystem.Map.Cell
{
    public enum CellAttribute
    {
        Fire,
        Gold,
        Wood,
        Water,
        Soil,
        Moon,
        Sun,
    }

    public enum CellType
    {
        Normal,
        //宝藏
        Treasure,
        //障碍
        Obstacle,

    }
    public abstract class MapCell
    {
        public class MapCellInfo
        {
            private int x;
            private int y;
            private CellAttribute attribute;
            private CellType type;
            private int moveCost;
            private static string prefabPath = "";
            bool canMove;

            public int X { get => x;}
            public int Y { get => y;}
            public CellAttribute Attribute { get => attribute;}
            public CellType Type { get => type;}
            public static string PrefabPath { get => prefabPath;}
            public int MoveCost { get => moveCost;}
            public bool CanMove { get => canMove;}
        }
        private MapCellInfo cellInfo;

        public MapCellInfo CellInfo { get => cellInfo;}


        public abstract void OnCharacterEnter(Character character);
       
    }
}
