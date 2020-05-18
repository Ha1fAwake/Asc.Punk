using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace GameSystem
{
    public enum GameState
    {
        MainMenu,
        Loading,
        Filght,
    }
    public class MainGame : MonoBehaviour
    {
        private GameState state;

        public GameState State
        {
            get => state;
            set
            {
                switch(value)
                {
                    case GameState.Loading:
                        break;
                    case GameState.MainMenu:
                        break;
                    case GameState.Filght:
                        break;
                }
            }
        }
    }
}
