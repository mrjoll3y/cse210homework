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
            CurrentRoom = "Room 1";
        }

        public void AddItem(string item)
        {
            Inventory.Add(item);
            Console.WriteLine($"You have picked up: {item}");
        }

        public void UseItem(string item)
        {
            if (Inventory.Contains(item))
            {
                if (item == "Health Potion")
                {
                    Health += 20;
                    Console.WriteLine("You used a Health Potion. Health +20.");
                    Inventory.Remove(item);
                }
                else
                {
                    Console.WriteLine($"You used the {item}");
                    Inventory.Remove(item);
                }
            }
            else
            {
                Console.WriteLine("You do not have that item.");
            }
        }
    }
}
