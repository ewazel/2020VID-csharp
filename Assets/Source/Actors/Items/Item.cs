using Assets.Source.Core;
using DungeonCrawl;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using Source.Core;

namespace Source.Actors.Items
{
    public abstract class Item : Actor
    {
        /// <summary>
        ///     All items are drawn "above" floor etc
        /// </summary>
        public override int Z => -1;
        
        public virtual void PickUp()
        {
            Player.inventory.Add(this);
            ActorManager.Singleton.DestroyActor(this);
            Player.Singleton.PrintInventory();
        }

        public abstract void Use();

        public void Heal(int value, string text)
        {
            Player.Singleton.ApplyDamage(value);
            Player.inventory.Remove(this);
            UserInterface.Singleton.SetText(text, UserInterface.TextPosition.MiddleLeft);
            Player.Singleton.PrintInventory();
            Player.Singleton.PrintHP();
        }
    }
    
    
    
}