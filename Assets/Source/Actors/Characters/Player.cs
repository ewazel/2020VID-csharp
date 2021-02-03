#nullable enable
using System.Collections.Generic;
using System.Linq;
using Assets.Source.Core;
using DungeonCrawl.Core;
using Source.Actors;
using Source.Actors.Items;
using Source.Actors.Static;
using Source.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {
        public static Player Singleton { get; private set; }
        public bool WearingMask { get; set; }
        
        public Player() : base()
        {
            Singleton = this;
            WearingMask = false;
        }
        protected override void OnUpdate(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                // Move up
                TryMove(Direction.Up);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                // Move down
                TryMove(Direction.Down);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                // Move left
                TryMove(Direction.Left);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                // Move right
                TryMove(Direction.Right);
            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Try pick up an item
                InteractWithItems();
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                Application.Quit();
            }
        }

        public static List<Item> inventory = new List<Item>();

        public void CountSteps()
        {
            UserInterface.Singleton.SetText(" ", UserInterface.TextPosition.BottomRight);
            if (!WearingMask) return;
            var maskInUse = inventory.FirstOrDefault(s => s is Mask);
            if (maskInUse is Mask)
            {
                maskInUse.Use();
            }
        }

        public override void TryMove(Direction direction)
        {
            base.TryMove(direction);
            CountSteps();
            
            var itemAtTargetPosition = ActorManager.Singleton.GetActorAt<Item>(Position);
            var doctorAtTargetPosition = ActorManager.Singleton.GetActorAt<Doctor>(Position);
            var virusesAtTargetPosition = ActorManager.Singleton.GetActorAt<Viruses>(Position);
            var doorAtTargetPosition = ActorManager.Singleton.GetActorAt<Door>(Position);
            var openDoorAtTargetPosition = ActorManager.Singleton.GetActorAt<OpenDoor>(Position);


            string message = "";
            
            if (itemAtTargetPosition)
            {
                message = "Press E to pick up.";
            }
            
            if (doorAtTargetPosition)
            {
                message = "Press E to open the gate.";
            }
            
            if (openDoorAtTargetPosition)
            {
                message = "Press E to get\nthrough the gate.";
            }

            if (doctorAtTargetPosition)
            {
                message = "Press E to get vaccinated.";
            }

            if (virusesAtTargetPosition)
            {
                virusesAtTargetPosition.stepOnViruses(this);
            }   
            UserInterface.Singleton.SetText(message, UserInterface.TextPosition.MiddleLeft);
        }

        private void InteractWithItems()
        {
            var itemAtPosition = ActorManager.Singleton.GetActorAt<Item>(Position);
            var doctorAtPosition = ActorManager.Singleton.GetActorAt<Doctor>(Position);
            var doorAtPosition = ActorManager.Singleton.GetActorAt<Door>(Position);
            var openDoorAtPosition = ActorManager.Singleton.GetActorAt<OpenDoor>(Position);

            if (itemAtPosition)
            {
                itemAtPosition.PickUp();
            }
            else if (doorAtPosition)
            {
                var firstMatch = inventory.FirstOrDefault(s => s.GetType() == typeof(Key));
                if (firstMatch is Key)
                {
                    firstMatch.Use();
                }
                else
                {
                    UserInterface.Singleton.SetText(Door.MessageNot, UserInterface.TextPosition.MiddleLeft);
                }
            }
            else if (openDoorAtPosition)
            {
                openDoorAtPosition.GetThrough();
            }
            else if (doctorAtPosition)
            { 
                var winningMatch = inventory.FirstOrDefault(s => s.GetType() == typeof(ChipVaccine));
                if (winningMatch is ChipVaccine)
                {
                    winningMatch.Use();
                }
                else
                {
                    var firstMatch = inventory.FirstOrDefault(s => s.GetType() == typeof(Vaccine));
                    if (firstMatch is Vaccine)
                    {
                        firstMatch.Use();
                    }
                    else
                    {
                        UserInterface.Singleton.SetText("Bring the vaccine first!", UserInterface.TextPosition.MiddleLeft);
                    }
                }
            }
            else
            {
                var firstMatch = inventory.FirstOrDefault(s => s.GetType() == typeof(AntibacterialGel));
                if (firstMatch is AntibacterialGel)
                {
                    firstMatch.Use();
                }
                else
                {
                    UserInterface.Singleton.SetText("You've run out of gel!", UserInterface.TextPosition.MiddleLeft);
                }
            }
        }
        
        public void PrintInventory() 
        {
            int vaccines = 0;
            int masks = 0;
            int dirtyMasks = 0;
            int key = 0;
            int antibacterialGels = 0;

            foreach (var item in inventory)
            {
                if (item is Vaccine || item is ChipVaccine)
                {
                    vaccines++;
                }
                else if (item is Mask)
                {
                    masks++;
                }
                else if (item is AntibacterialGel)
                {
                    antibacterialGels++;
                }
                else if (item is DirtyMask)
                {
                    dirtyMasks++;
                }
                else if (item is Key)
                {
                    key++;
                }
            }
            
            string text = $"INVENTORY:\nVaccines: {vaccines}\nAntibacterial Gels: {antibacterialGels}\nMasks: {masks}\nDirty masks: {dirtyMasks}\nKey: {key}";
            UserInterface.Singleton.SetText(text, UserInterface.TextPosition.BottomLeft);
        }

        /*private Item GenericTest<T>() where T: Item
        {
            foreach (var item in inventory)
            {
                if (item.GetType() == typeof(T))
                {
                    return item;
                }
            }

            return null;
        }*/
        
        //GenericTest<Mask>();

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }

        protected override void OnDeath()
        {
            Debug.Log("Oh no, I'm dead!");
        }

        public override int DefaultSpriteId => 24;
        public override string DefaultName => "Player";
    }
}
