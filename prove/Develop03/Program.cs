using System;

namespace TextAdventureGame
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the Enhanced Text Adventure Game!");
            Console.Write("Enter your character's name: ");
            string playerName = Console.ReadLine();
            Player player = new Player(playerName);

            Room room1 = new Room("Room 1", "A dark room with a heavy door.",
                new string[] { "Try to force the door open", "Look for a key", "Leave" },
                new string[] { "You fail, and injure yourself slightly.", "You find a key under a table.", "You leave the room." },
                "Corridor 1", "Health Potion");

            Room corridor1 = new Room("Corridor 1", "A narrow hallway with flickering lights.",
                new string[] { "Move ahead", "Inspect the walls", "Turn back" },
                new string[] { "You move ahead but feel uneasy.", "You find a hidden compartment with a mysterious object.", "You retreat to Room 1." },
                "Room 2", "Strength Boost");

            Room room2 = new Room("Room 2", "A room filled with puzzles.",
                new string[] { "Solve the puzzle", "Inspect the surroundings" },
                new string[] { "You solve the puzzle and feel smarter.", "You find a scroll with an ancient map." },
                "Secret Passage", "Intelligence Scroll", false, false, true);

            Room secretPassage = new Room("Secret Passage", "A narrow, winding tunnel.",
                new string[] { "Proceed cautiously", "Retreat" },
                new string[] { "You hear something behind you, but you keep going.", "You leave and return to Room 2." },
                "Room 3", "Key to Treasure Chest", true);

            Room room3 = new Room("Room 3", "A room with a treasure chest.",
                new string[] { "Open the chest", "Look around the room" },
                new string[] { "The chest is locked. You need a key.", "You find a hidden door leading out." },
                "Treasure Room", "Health Potion", true);

            Room treasureRoom = new Room("Treasure Room", "A room filled with treasure chests and gold.",
                new string[] { "Take the treasure", "Leave the treasure" },
                new string[] { "You grab the treasure, but a trap is triggered!", "You decide not to take the treasure and leave." },
                "Exit", "Golden Key", false);

            Room exitRoom = new Room("Exit", "You see a bright light in the distance.",
                new string[] { "Go towards the light", "Turn around" },
                new string[] { "You escape and win!", "You turn around and fall into a pit!" },
                "End", "None");

            // Game loop
            bool gameRunning = true;
            while (gameRunning)
            {
                Console.Clear();
                Console.WriteLine($"Your Health: {player.Health}, Strength: {player.Strength}, Intelligence: {player.Intelligence}");
                Console.WriteLine($"Current Room: {player.CurrentRoom}");

                switch (player.CurrentRoom)
                {
                    case "Room 1":
                        room1.EnterRoom();
                        room1.ShowChoices();
                        int choice = GetValidChoice(room1.Choices.Length);
                        room1.HandleChoice(choice, player);
                        player.CurrentRoom = room1.NextRoom;
                        break;

                    case "Corridor 1":
                        corridor1.EnterRoom();
                        corridor1.ShowChoices();
                        choice = GetValidChoice(corridor1.Choices.Length);
                        corridor1.HandleChoice(choice, player);
                        player.CurrentRoom = corridor1.NextRoom;
                        break;

                    case "Room 2":
                        room2.EnterRoom();
                        room2.ShowChoices();
                        choice = GetValidChoice(room2.Choices.Length);
                        room2.HandleChoice(choice, player);
                        player.CurrentRoom = room2.NextRoom;
                        break;

                    case "Secret Passage":
                        secretPassage.EnterRoom();
                        secretPassage.ShowChoices();
                        choice = GetValidChoice(secretPassage.Choices.Length);
                        secretPassage.HandleChoice(choice, player);
                        player.CurrentRoom = secretPassage.NextRoom;
                        break;

                    case "Room 3":
                        room3.EnterRoom();
                        room3.ShowChoices();
                        choice = GetValidChoice(room3.Choices.Length);
                        room3.HandleChoice(choice, player);
                        player.CurrentRoom = room3.NextRoom;
                        break;

                    case "Treasure Room":
                        treasureRoom.EnterRoom();
                        treasureRoom.ShowChoices();
                        choice = GetValid
