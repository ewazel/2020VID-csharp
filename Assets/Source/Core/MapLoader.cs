using DungeonCrawl.Actors.Characters;
using System;
using System.Text.RegularExpressions;
using Source.Actors.Characters;
using Source.Actors.Items;
using Source.Actors.Static;
using Source.Core;
using UnityEngine;

namespace DungeonCrawl.Core
{
    /// <summary>
    ///     MapLoader is used for constructing maps from txt files
    /// </summary>
    public static class MapLoader
    {
        /// <summary>
        ///     Constructs map from txt file and spawns actors at appropriate positions
        /// </summary>
        /// <param name="id"></param>
        public static void LoadMap(int id)
        {
            var lines = Regex.Split(Resources.Load<TextAsset>($"map_{id}").text, "\r\n|\r|\n");

            // Read map size from the first line
            var split = lines[0].Split(' ');
            var width = int.Parse(split[0]);
            var height = int.Parse(split[1]);

            // Create actors
            for (var y = 0; y < height; y++)
            {
                var line = lines[y + 1];
                for (var x = 0; x < width; x++)
                {
                    var character = line[x];

                    SpawnActor(character, (x, -y));
                }
            }

            // Set default camera size and position
            CameraController.Singleton.Size = 10;
            CameraController.Singleton.Position = (width / 2, -height / 2);
        }

        private static void SpawnActor(char c, (int x, int y) position)
        {
            switch (c)
            {
                case '#':
                    ActorManager.Singleton.Spawn<Wall>(position);
                    break;
                case '.':
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'p':
                    ActorManager.Singleton.Spawn<Player>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'v':
                    ActorManager.Singleton.Spawn<AntiVaccine>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 's':
                    ActorManager.Singleton.Spawn<SuperSpreader>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'g':
                    ActorManager.Singleton.Spawn<Grandma>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case ' ':
                    break;
                case 'i':
                    ActorManager.Singleton.Spawn<Vaccine>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'c':
                    ActorManager.Singleton.Spawn<ChipVaccine>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'm':
                    ActorManager.Singleton.Spawn<Mask>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'a':
                    ActorManager.Singleton.Spawn<AntibacterialGel>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'u':
                    ActorManager.Singleton.Spawn<DirtyMask>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'd':
                    ActorManager.Singleton.Spawn<Doctor>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'w':
                    ActorManager.Singleton.Spawn<Viruses>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case '@':
                    ActorManager.Singleton.Spawn<Door>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case '0':
                    ActorManager.Singleton.Spawn<OpenDoor>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    ActorManager.Singleton.Spawn<Player>(position);
                    break;
                case 'k':
                    ActorManager.Singleton.Spawn<Key>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
