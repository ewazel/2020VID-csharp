using System.Linq;
using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using Source.Actors.Items;
using Source.Core;
using UnityEngine;

namespace Source.Actors.Static
{
    public class Door : Actor
    {
        private static string Message = "The gate is open!";
        public static string MessageNot = "No key, no entry!";

        public void Open()
        {
            ActorManager.Singleton.Spawn<OpenDoor>(Position);
            ActorManager.Singleton.DestroyActor(this);
        }
        
        public override int DefaultSpriteId => 432;

        public override string DefaultName => "Door";
    }
}