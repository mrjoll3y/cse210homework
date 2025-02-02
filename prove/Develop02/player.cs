using System;
using System.Collections.Generic;

namespace TextAdventureGame
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public List<string> Inventory { get; set; }
        public string CurrentRoom { get; set; }

        public Player(string name)
        {
            Name = name;
            Health = 100;
            Strength = 10;
            Intelligence = 10;
            Inventory = new List<string>();
            CurrentRoom = "Room 1"; // Starting point
        }

        public void AddItem(string item)
        {
            Inventory.Add(item);
        }
    }
}
