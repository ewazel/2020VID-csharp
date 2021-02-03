using System.Linq;
using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using Source.Actors.Items;
using Source.Core;
using UnityEngine;

namespace Source.Actors.Static
{
    public class OpenDoor : Actor
    {
        //private static string Message = "The gate is open!";
        //public static string MessageNot = "No key, no entry!";
        private int currentMap;
        private int targetMap;

        public OpenDoor()
        {
            currentMap = GameManager.CurrentMap;
            switch (currentMap)
            {
                case 1:
                case 3:
                    targetMap = 2;
                    break;
                case 2:
                    targetMap = 3;
                    break;
            }
        }

        public void GetThrough()
        {
            GameManager.CurrentMap = targetMap;
            ActorManager.Singleton.DestroyAllActors();
            MapLoader.LoadMap(targetMap);
            //ActorManager.Singleton.Spawn<Player>((2,-1));
        }
        
        public override int DefaultSpriteId => 433;

        public override string DefaultName => "OpenDoor";
    }
}