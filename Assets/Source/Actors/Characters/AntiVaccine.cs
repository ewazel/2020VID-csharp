using System.Collections.Generic;
using DungeonCrawl;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using UnityEngine;

namespace Source.Actors.Characters
{
    public class AntiVaccine : Character
    {
        System.Random random = new System.Random();
        List<int> list = new List<int> {1, 2, 3, 4, 5};
        private int _count = 0;
        private int _count2 = 0;

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }

        protected override void OnUpdate(float deltaTime)
        {
            int index = random.Next(list.Count);
            if (_count < 1)
            {
                if (index == 1)
                {
                    TryMove(Direction.Up);
                    _count++;
                }

                if (index == 2)
                {
                    // Move down
                    TryMove(Direction.Down);
                    _count++;
                }

                if (index == 3)
                {
                    // Move left
                    TryMove(Direction.Left);
                    _count++;
                }

                if (index == 4)
                {
                    // Move right
                    TryMove(Direction.Right);
                    _count++;
                }
            }
            else if (_count2 > 200)
            {
                _count = 0;
                _count2 = 0;
            }

            _count2++;
        }

        protected override void OnDeath()
        {
            Debug.Log("Well, I was already dead anyway...");
        }

        public override int DefaultSpriteId => 316;
        public override string DefaultName => "AntiVaccine";
    }
}