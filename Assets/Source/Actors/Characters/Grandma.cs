using Source.Actors;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Grandma : Character
    {
        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }

        protected override void OnDeath()
        {
            Debug.Log("Well, I have lived my life...");
        }

        public override int DefaultSpriteId => 172;
        public override string DefaultName => "Grandma";
    }
}