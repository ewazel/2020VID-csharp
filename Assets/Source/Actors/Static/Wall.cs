using DungeonCrawl.Actors;

namespace Source.Actors.Static
{
    public class Wall : Actor
    {
        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }
        
        public override int DefaultSpriteId => 825;
        public override string DefaultName => "Wall";
    }
}
