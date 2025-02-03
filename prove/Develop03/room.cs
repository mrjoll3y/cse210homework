// Game.cs
using System;
using System.Collections.Generic;

namespace AdventureGame
{
    class Game
    {
        private Player player;
        private Dictionary<string, Room> rooms;

        public Game()
        {
            rooms = new Dictionary<string, Room>();
            InitializeRooms();
        }

        public void Start()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            player = new Player(name);
            Console.WriteLine($"Welcome, {player.Name}! Your adventure begins...");
            Navigate("Room1");
        }

        private void InitializeRooms()
        {
            rooms["Room1"] = new Room("Room1", "You wake up in a dark cave. There are two paths ahead.",
                new Dictionary<string, string>
                {
                    { "Take the left path", "Room2" },
                    { "Take the right path", "Room3" }
                });

            rooms["Room2"] = new Room("Room2", "You encounter a river. A broken bridge is in front of you.",
                new Dictionary<string, string>
                {
                    { "Try to cross the bridge", "Room4" },
                    { "Search for another way", "Room5" }
                });

            rooms["Room3"] = new Room("Room3", "A strange merchant appears. He offers you a mysterious potion.",
                new Dictionary<string, string>
                {
                    { "Drink the potion", "Room6" },
                    { "Refuse and continue", "Room7" }
                });

            rooms["Room4"] = new Room("Room4", "The bridge collapses! You fall into the river and are carried away.",
                new Dictionary<string, string>
                {
                    { "Swim to shore", "Room8" }
                });

            rooms["Room5"] = new Room("Room5", "You find a hidden boat and cross safely.",
                new Dictionary<string, string>
                {
                    { "Continue ahead", "Room8" }
                });

            rooms["Room6"] = new Room("Room6", "The potion grants you night vision! You see a hidden tunnel.",
                new Dictionary<string, string>
                {
                    { "Enter the tunnel", "Room9" }
                });

            rooms["Room7"] = new Room("Room7", "You ignore the merchant and move forward.",
                new Dictionary<string, string>
                {
                    { "Explore further", "Room10" }
                });

            rooms["Room8"] = new Room("Room8", "You arrive at an abandoned village with five strange houses.",
                new Dictionary<string, string>
                {
                    { "Enter the biggest house", "Outcome1" },
                    { "Enter the smallest house", "Outcome2" }
                });

            rooms["Room9"] = new Room("Room9", "The tunnel leads to a treasure room!", 
                new Dictionary<string, string>
                {
                    { "Claim the treasure", "Outcome3" }
                });

            rooms["Room10"] = new Room("Room10", "A deadly beast blocks your path!", 
                new Dictionary<string, string>
                {
                    { "Fight the beast", "Outcome4" },
                    { "Run away", "Outcome5" }
                });
        }

        private void Navigate(string roomKey)
        {
            if (!rooms.ContainsKey(roomKey))
            {
                Console.WriteLine("Invalid room!");
                return;
            }

            Room currentRoom = rooms[roomKey];
            Console.WriteLine($"\n{currentRoom.Description}");

            if (roomKey.StartsWith("Outcome"))
            {
                Console.WriteLine("Game Over. Thanks for playing!");
                return;
            }

            Console.WriteLine("Choose an action:");
            int i = 1;
            foreach (var choice in currentRoom.Choices)
            {
                Console.WriteLine($"{i}. {choice.Key}");
                i++;
            }

            int choiceIndex = GetChoice(currentRoom.Choices.Count);
            string nextRoom = currentRoom.Choices[new List<string>(currentRoom.Choices.Keys)[choiceIndex - 1]];
            Navigate(nextRoom);
        }

        private int GetChoice(int maxChoices)
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > maxChoices)
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
            return choice;
        }
    }
}
