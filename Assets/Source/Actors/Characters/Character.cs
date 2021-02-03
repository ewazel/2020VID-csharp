using Assets.Source.Core;
using DungeonCrawl.Core;
using Source.Actors;
using Source.Core;

namespace DungeonCrawl.Actors.Characters
{
    public abstract class Character : Actor
    {
        public int Health { get; protected set; }
        
        protected Character() 
        {
            Health = 100;
        }

        public void ApplyDamage(int damage)
        {
            Health -= damage;

            if (Health <= 0)
            {
                // Die
                OnDeath();

                ActorManager.Singleton.DestroyActor(this);
            }
        }
        
        public void PrintHP()
        {
            string text = $"HEALTH: {Health}";
            UserInterface.Singleton.SetText(text, UserInterface.TextPosition.TopLeft);
        }

        protected abstract void OnDeath();

        /// <summary>
        ///     All characters are drawn "above" floor etc
        /// </summary>
        public override int Z => -1;
    }
}
