using System.Collections.Generic;

namespace TextAdventureGame
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public string CurrentRoom { get; set; }
        public List<string> Inventory { get; set; }

        public Player(string name)
        {
            Name = name;
            Health = 100; // Starting health
            CurrentRoom = "Room 1"; // Starting room
            Inventory = new List<string>(); //
