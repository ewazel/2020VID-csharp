using Assets.Source.Core;
using DungeonCrawl;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using Source.Core;

namespace Source.Actors.Static
{
    public class Viruses : Actor
    {
        private const int Value = 5;
        private const string Message = "You stepped into the big\ncloud of viruses!";
        
        public void stepOnViruses(Actor actor)
        {
            if (actor is Player)
            {
                if (!Player.Singleton.WearingMask)
                {
                    Player.Singleton.ApplyDamage(Value);
                    ActorManager.Singleton.DestroyActor(this);
                    Player.Singleton.PrintHP();
                    UserInterface.Singleton.SetText(Message, UserInterface.TextPosition.BottomRight);
                }
            }
        }
        
        public override int DefaultSpriteId => 6;
        public override string DefaultName => "Viruses";
    }
}