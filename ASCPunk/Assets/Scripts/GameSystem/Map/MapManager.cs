using GameSystem.FightSystem;
using GameSystem.Map.Cell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
namespace GameSystem.Map
{
    public class MapManager : MonoBehaviour
    {
        private MapData curMapData;
        private MapData nextMapData;
        private MapData preMapData;
        private List<List<GameObject>> mapCubes;
        GameObject mapRoot;
        string[] path = { "Prefabs/green", "Prefabs/red", "Prefabs/blue" };
        GameObject player;
        GameObject mobablePlane;
        public Button button;
        public InputField textEditorx;
        public InputField textEditory;

        private void Awake()
        {
            mapCubes = new List<List<GameObject>>();
            player = GameObject.Find("player");
            MapCell[][] s = new MapCell[10][];
            for (int i = 0; i < s.Length; i++)
            {
                s[i] = new MapCell[10];
            }
            curMapData = new MapData(s);
            mapRoot = new GameObject("mapRoot");
            mapRoot.transform.position = new Vector3(0, 0, 0);
            StartCoroutine(DrawMap());
            button.onClick.AddListener(() =>
            {
                string x = textEditorx.text;
                string y = textEditory.text;
                StartCoroutine(Move(int.Parse(x), int.Parse(y), player));
            });
        }
        public IEnumerator<int> DrawMap()
        {
            for (int i = 0; i < curMapData.MapCells.Length; i++)
            {
                mapCubes.Add(new List<GameObject>());
                for (int j = 0; j < curMapData.MapCells[i].Length; j++)
                {
                    DrawMapCell(curMapData.MapCells[i][j], i, j);
                }
                yield return 0;
            }
            yield break;
        }

        public void MoveTo(int x, int y, GameObject go)
        {
            go.transform.position = new Vector3(x, 1.5f, y);
        }

        public IEnumerator<int> Move(int x, int y, GameObject go)
        {
            var source = go.transform.position;
            var target = new Vector3(x, go.transform.position.y, y);
            float timer = 0;
            while (timer <= 1.5f)
            {
                timer += Time.deltaTime;
                go.transform.position = Vector3.Lerp(go.transform.position, target, Time.deltaTime * 3.5f);
                yield return 0;
            }
            go.transform.position = target;
            yield break;
        }

        private void DrawMapCell(MapCell cell, int x, int y)
        {
            int m = UnityEngine.Random.Range(0, 3);
            var obj = Resources.Load<GameObject>(path[m % 3]);
            var gameObj = Instantiate(obj);
            gameObj.transform.parent = mapRoot.transform;
            gameObj.transform.position = new Vector3(x, 0, y);
            mapCubes[x].Add(gameObj);
        }

        public void ShowMovePath(Character character)
        {
            DrawMovePath(character.Position, curMapData.MapCells.Length, character.MovingForce);
        }

        private void DrawMovePath(Vector2 pos, int movingForce, int maxIndex)
        {
            Vector2[] aroundPos = new Vector2[] { new Vector2(pos.x + 1, pos.y), new Vector2(pos.x - 1, pos.y), new Vector2(pos.x, pos.y + 1), new Vector2(pos.x + 1, pos.y - 1) };
            foreach (var p in aroundPos)
            {
                var cell = curMapData.MapCells[(int)p.x][(int)p.y];
                if (cell.CellInfo.CanMove && CheckMapEdge(p,maxIndex) && movingForce - cell.CellInfo.MoveCost >= 0)
                {
                    movingForce -= cell.CellInfo.MoveCost;
                    DrawMovePath(p, movingForce, maxIndex);
                    continue;
                }
            }
        }

        private void  DrawCellMovable(int x, int y)
        {
            var plane = Instantiate(mobablePlane);
            plane.transform.position = new Vector3(x, mapCubes[x][y].transform.position.y + 0.5f, y);
        }

        private bool CheckMapEdge(Vector2 p, int maxIndex)
        {
            return p.x <= maxIndex && p.y <= maxIndex && p.x >= 0 && p.y >= 0;
        }
       
        public void DrawCurMap()
        {

        }

        public void AsyncPreLoadNextMapData(string mapName)
        {

        }

        public void AsyncLoadMapData(string mapName)
        {

        }

        public void AsyncLoadNextMap()
        {
            if (curMapData.NextMapName != null)
            {
                AsyncLoadMapData(curMapData.NextMapName);
            }
            else
            {
                Debug.LogError("next map is null");
                throw new Exception("next map is null");
            }

        }

        public void ReleasePreMapData()
        {

        }

        public void ReleaseNextMapData()
        {

        }

        public void OnCharacterEnterMapCell(int x, int y, Character character)
        {
            var cell = curMapData.MapCells[x][y];
            cell.OnCharacterEnter(character);
        }



    }
}
