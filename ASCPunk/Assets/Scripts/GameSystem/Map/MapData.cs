using GameSystem.Map.Cell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Tilemaps;

namespace GameSystem.Map
{
    public enum TileType
    {

    }
    public class MapData
    {
        private MapCell[][] mapCells;
        private string nextMapName;

        public MapData(MapCell[][] mapCells)
        {
            this.mapCells = mapCells;
        }

        /// <summary>
        /// 地图的所有瓦片
        /// </summary>
        public MapCell[][] MapCells { get => mapCells; set => mapCells = value; }
        /// <summary>
        /// 该地图下一张地图的地图名
        /// </summary>
        public string NextMapName { get => nextMapName; set => nextMapName = value; }
    }
}
