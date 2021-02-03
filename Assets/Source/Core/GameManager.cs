using System;
using Assets.Source.Core;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using Source.Actors.Items;
using Source.Actors.Static;
using Source.Core;
using UnityEngine;

namespace DungeonCrawl.Core
{
    /// <summary>
    ///     Loads the initial map and can be used for keeping some important game variables
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static int CurrentMap = 1;
        private void Start()
        {
            MapLoader.LoadMap(CurrentMap);
            Player.Singleton.PrintHP();
            Player.Singleton.PrintInventory();
        }

        private void Update()
        {
//            UserInterface.Singleton.SetText(Utilities.PrintHP(), UserInterface.TextPosition.TopLeft);
        }

        
    }
}
