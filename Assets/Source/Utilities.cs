using System;
using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using Source.Actors.Items;
using UnityEngine;

namespace DungeonCrawl
{
    public enum Direction : byte
    {
        Up,
        Down,
        Left,
        Right
    }

    public static class Utilities
    {
        public static (int x, int y) ToVector(this Direction dir)
        {
            switch (dir)
            {
                case Direction.Up:
                    return (0, 1);
                case Direction.Down:
                    return (0, -1);
                case Direction.Left:
                    return (-1, 0);
                case Direction.Right:
                    return (1, 0);
                default:
                    throw new ArgumentOutOfRangeException(nameof(dir), dir, null);
            }
        }
        

        // public static void PrintHP(int HP)
        // {
        //     //var player = ActorManager.Singleton.GetSprite(24);
        //     string text = $"HEALTH: {Player.Singleton.Health}";
        //     UserInterface.Singleton.SetText(text, UserInterface.TextPosition.TopLeft);
        // }
    }
}
