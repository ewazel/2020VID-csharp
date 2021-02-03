# Dungeon Crawl (sprint 1)

## Story

[Roguelikes](https://en.wikipedia.org/wiki/Roguelike) are one of the oldest
types of video games, the earliest ones were made in the 70s, they were inspired
a lot by tabletop RPGs. Roguelikes have the following in common usually:

- They are tile-based.
- The game is divided into turns, e.g. you make one action, then the other
  entities (monsters, allies, etc. controlled by the CPU) make one.
- Usually the task is to explore a labyrinth and retrieve some treasure from its
  bottom.
- They feature permadeath: if you die its game over, you need to start from the
  beginning again.
- Are heavily using procedural generation: Levels, monster placement, items,..
  are randomized, so the game does not get boring.

Your task will be to create a roguelike! You can deviate from the rules above,
the important bit is that it should be fun!

## What are you going to learn?

- Get more practice in OOP
- Design patterns: layer separation (All of the game logic, i.e., player
  movement, game rules, and so on), is in the `logic` package, completely
  independent of user interface code. In principle, you could implement a
  completely different interface e.g. terminal, web, Virtual Reality, etc. for
  the same logic code.)

## Tasks

1. Understand the existing code, classes and tests so you can make changes. You should do this before planning everything else. It will help you understand what is going on.
    - Student has a class diagram in a digialized format which 
- contains enums, classes, interfaces with all fields, methods
- show connections between classes: inheritance, aggregation, composition
- show multiplicity of connections (1..1, 1..*, *..*)

2. Create a game logic which restricts the movement of the player so s/he cannot run into walls and monsters.
    - The hero is not able to move into walls.
    - The hero is not able to move into monsters.

3. There are items lying around the dungeon. They are visible in the GUI.
    - There are at least 2 item types, for instance a key, and a sword.
    - There can be one item in a map square.
    - A player can stand on the same square as an item.
    - The item has to be displayed on screen (unless somebody stands on the same square)

4. Create a feature that allows the hero to pick up an item.
    - In the bottom right corner, "Press E to pick up" text appear when hero can pick an item.
    - After the player clicks the E key, the item the hero is standing on should be gone from map.

5. Show picked up items in the inventory list.
    - There is an `Inventory` list on the screen.
    - After the hero picks up an item, it should appear in inventory.

6. Make the hero to able to attack monsters by moving into them.
    - Attacking a monster removes 5 health points. If health of a monster goes below 0, it dies and disappears.
    - Create a feature where the hero attack a monster, and it doesn't die, it also attacks the hore at the same time (but is a bit weaker, and only removes 2 health).
    - Having a weapon should increase your attack strength.
    - Different monsters have different health and attack strength.

7. Create doors in the dungeon that open by using keys.
    - There are two new square types, closed door, and open door.
    - The hero cannot pass through a closed door, unless it has a key in his/her inventory. Then it becomes an open door.

8. Create three different monster types with different behaviors.
    - There are at least three different monster types with different behaviors.
    - One type of monster does not move at all.
    - One type of monster moves randomly. It cannot go trough walls or open doors.

9. [OPTIONAL] Create a more sophisticated movement AI.
    - One type of monster moves around randomly and teleports to a random free square every few turns.
    - A custom movement logic is implemented (like Ghosts that can move trough walls, monster that chases the player, etc.)

10. Create maps that have more varied scenery. Take a look at the tile sheet (tiles.png). Get inspired!
    - At least three more tiles are used. These can be more monsters, items, or background. At least one of them has to be not purely decorative, but have some effect on gameplay.

11. [OPTIONAL] Allow the player to set a name for my character. This name will also function as a cheat code!
    - There is a `Name` label and text field on the screen.
    - If the name given is one of the game developers' name, the player can walk through walls.

12. [OPTIONAL] Make the game sound fun by implementing audio effects, when player or enemies do stuff
    - There is a footstep sound, that plays, whenever the player takes a step
    - There is an attack sound, whenever player and/or an enemy attacks someone This sound might vary depending on the weapon (sword, axe, arrow)
    - Enemies such as skeletons or ghosts play characteristic sounds randomly every few seconds
    - Add some background music to your game!

13. Add the possibility to add more levels.
    - There are at least two levels.
    - There is a square type "stairs down". Entering this square moves the player to a different map.

14. Implement bigger levels than the game window.
    - Levels are larger than the game window (for example 3 screens wide and 3 screens tall).
    - When the player moves the player character stays in the center of the view.

## General requirements

None

## Hints

- Start with the smaller tasks, and then move into the more difficult ones
- Before making any changes make sure you understand the whole starting code
- This project uses Unity game engine to run the game. It's an advanced game development tool
with multiple features, but don't worry - you don't have to learn it (unless you want to).
All the essential features, like moving the characters, spawning new actors, etc, have been simplified
with some custom framework code. Below in Background section, you'll find information on how to setup Unity
to start working on the project.
- Before starting to work on the project, you have to link Unity with C# IDE of your choice (Visual Studio or Rider).
Here's the documentation on how to do it: (https://docs.unity3d.com/Manual/Preferences.html#External-Tools)
- After opening the project for the first time, be sure to open the Game scene in Scenes folder, in the Project section at the bottom.
- There are only two things you'll have to do in Unity editor: start the game by pressing the PLAY button
in the upper center part of the screen; and start the C# solution, by pressing right mouse button in the 
Project window in the bottom part of the screen, and then pressing Open C# Solution. Whenever you want to test
the game after applying some changes in the code, be sure to save all the files (CTRL+Shift+S might be helpful).
Then, after switching to Unity editor window, before starting the game,
you'll have to wait until Unity recompiles the code (it should take 10-60 seconds).
- Since the start code provides simple tools to interact with Unity, don't modify the provided methods, because
this might break or alter the game's behaviour.
- Several classes in this project utilize _Singleton pattern_. You'll find more info about it in Background section.


## Background materials

- <i class="far fa-book-open"></i> [RogueBasin, a wiki with lots of resources on Roguelike creation](http://roguebasin.com/index.php?title=Articles)
- <i class="far fa-exclamation"></i> [Basics of OOP](project/curriculum/materials/pages/oop/basics-of-object-oriented-programming.md)
- <i class="far fa-exclamation"></i> [UML diagrams](project/curriculum/materials/pages/general/uml-unified-modeling-language.md)
- <i class="far fa-exclamation"></i> [How to design classes](project/curriculum/materials/pages/csharp/how-to-design-classes.md)
- <i class="far fa-exclamation"></i> [Unity setup](https://docs.unity3d.com/Manual/GettingStartedInstallingHub.html) After installing Unity, open the Unity Hub, press the "Add" button and navigate to the project's folder
- <i class="far fa-book-open"></i> [Unity Documentaton](https://docs.unity3d.com/Manual/index.html) You dont need to dwelve into this, most of the game mechanics and UI is ready
- <i class="far fa-book-open"></i> [Singleton Pattern](https://www.dofactory.com/net/singleton-design-pattern)
- <i class="far fa-book-open"></i> [How to add sounds in Unity](https://support.unity.com/hc/en-us/articles/206116056-How-do-I-use-an-Audio-Source-in-a-script-) For the additional task
- Reference: the tiles used in the game are from [1-Bit Pack by Kenney](https://kenney.nl/assets/bit-pack), shared on [CC0 1.0 Universal license](https://creativecommons.org/publicdomain/zero/1.0/).
