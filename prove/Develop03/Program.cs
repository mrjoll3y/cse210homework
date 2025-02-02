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

            Room room1 = new Room("Room 1", "You wake up in a dark, cold room with a heavy door. The faint sound of water dripping echoes through the space. The only light comes from a small crack in the ceiling.",
                new string[] { "Try to force the door open", "Look for a key", "Leave the room" },
                new string[] { 
                    "You attempt to force the door open but strain your shoulder. You lose 5 health. Not an ideal start.",
                    "You look around the room and find a dusty key hidden under a loose floorboard. The key might unlock the door.",
                    "You decide to leave the room, but the hall outside seems endless and unnerving. You turn back to the room." },
                "Corridor 1", "Health Potion");

            Room corridor1 = new Room("Corridor 1", "You step into a narrow, dimly lit corridor. The air is thick with dust and something...else. The faint sound of whispering seems to come from nowhere.",
                new string[] { "Move ahead", "Inspect the walls", "Turn back" },
                new string[] { 
                    "You take a cautious step forward. The whispering grows louder, but you keep moving.",
                    "You run your fingers along the walls and discover a hidden compartment containing a small but glowing object. Perhaps it has some use.",
                    "You turn around and leave the corridor, but you can't shake the feeling of being watched." },
                "Room 2", "Strength Boost");

            Room room2 = new Room("Room 2", "You find yourself in a room filled with old, dusty bookshelves. At the center of the room is a large wooden table with several strange puzzle pieces scattered on it.",
                new string[] { "Solve the puzzle", "Inspect the surroundings" },
                new string[] { 
                    "You start piecing together the puzzle and find an ancient map hidden underneath. You feel more intelligent after solving it.",
                    "You search the room and find a scroll with cryptic symbols. Perhaps the solution to the puzzle lies within." },
                "Secret Passage", "Intelligence Scroll", false, false, true);

            Room secretPassage = new Room("Secret Passage", "A narrow, winding tunnel opens up ahead. The passage is damp, and you feel a chill running down your spine. The air grows colder as you progress.",
                new string[] { "Proceed cautiously", "Retreat" },
                new string[] { 
                    "You proceed cautiously, your steps echoing in the tunnel. You feel like you're being watched.",
                    "You retreat, unsure of the dangers that lie ahead, and return to Room 2." },
                "Room 3", "Key to Treasure Chest", true);

            Room room3 = new Room("Room 3", "The passage opens up into a large room. In the center is a treasure chest, locked tight. The chest looks old but valuable. In the corners, there are ornate statues that seem to watch you.",
                new string[] { "Open the chest", "Look around the room" },
                new string[] { 
                    "You attempt to open the chest, but it's locked. You’ll need a key.",
                    "You examine the room more carefully and find a hidden lever. Pulling it opens a secret door leading out." },
                "Treasure Room", "Health Potion", true);

            Room treasureRoom = new Room("Treasure Room", "Inside this room, you see chests brimming with gold and jewels. But something about the room feels off. You hear the faint clicking of traps activating.",
                new string[] { "Take the treasure", "Leave the treasure" },
                new string[] { 
                    "You decide to grab the treasure, but as soon as you do, a trap is triggered! A dart pierces your arm. You lose 20 health.",
                    "You leave the treasure, walking away unharmed but with a strange feeling that you might have missed something important." },
                "Exit", "Golden Key", false);

            Room exitRoom = new Room("Exit", "You reach the final chamber, bathed in a soft golden light. The exit is before you, but the journey has been long and the choices tough.",
                new string[] { "Go towards the light", "Turn around" },
                new string[] { 
                    "You step into the light, and suddenly everything goes quiet. You escape with the treasure and live to tell the tale. Victory is yours!",
                    "You turn around, but the ground beneath you gives way. You fall into darkness. The game ends in failure." },
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
                       
