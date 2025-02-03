// Room.cs & Player.cs
using System;
using System.Collections.Generic;

namespace AdventureGame
{
    class Player
    {
        public string Name { get; set; }
        public Player(string name)
        {
            Name = name;
        }
    }

    class Room
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, string> Choices { get; set; }

        public Room(string name, string description, Dictionary<string, string> choices)
        {
            Name = name;
            Description = description;
            Choices = choices;
        }
    }
}