using System;

namespace TextAdventureGame
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the Expanded Text Adventure Game!");
            Console.Write("Enter your character's name: ");
            string playerName = Console.ReadLine();

            // Create a player object with the entered name
            Player player = new Player(playerName);

            // Room instances with consequences based on choices
            Room room1 = new Room("Room 1", "A simple, unremarkable room with a faint light in the corner.",
                new string[] { "Go north", "Stay" },
                new string[] { "You step into the unknown.", "You stay and do nothing." }, "Corridor 7");

            Room corridor7 = new Room("Corridor 7", "The corridor stretches ahead with strange whispers.",
                new string[] { "Investigate whispers", "Continue ahead", "Turn back" },
                new string[] { "You find a hidden trap!", "You press forward, the path ahead is uncertain.", "You decide to turn back." }, "Vault");

            Room vault = new Room("Vault", "A vault with intricate mechanisms, but no visible way in.",
                new string[] { "Inspect the vault", "Leave the vault" },
                new string[] { "The vault opens, but danger awaits inside.", "You decide to leave the vault." }, "Passageway");

            Room passageway = new Room("Passageway", "A narrow, dark passageway. It's almost suffocating.",
                new string[] { "Push forward", "Retreat" },
                new string[] { "You feel something watching you.", "You decide to retreat." }, "Void");

            Room voidRoom = new Room("Void", "A pitch-black void. You can’t see a thing.",
                new string[] { "Search for light", "Wait in the dark" },
                new string[] { "You find a small light source, but it’s only a false hope.", "The darkness consumes you." }, "Area 3");

            Room area3 = new Room("Area 3", "A series of strange glowing symbols line the walls.",
                new string[] { "Investigate the symbols", "Walk through" },
                new string[] { "The symbols reveal a hidden exit.", "You feel disoriented and dizzy." }, "Room of Mirrors");

            Room roomOfMirrors = new Room("Room of Mirrors", "A room full of mirrors, but they don’t reflect you.",
                new string[] { "Take the object from the mirror", "Leave" },
                new string[] { "You gain strength from the object.", "You leave, unsure of your decision." }, "Chamber of Time");

            Room chamberOfTime = new Room("Chamber of Time", "A room that seems to distort time itself.",
                new string[] { "Continue through", "Wait and see what happens" },
                new string[] { "You step through a time portal, but it leads to a trap!", "You wait, and a mysterious figure appears." }, "Underpass");

            Room underpass = new Room("Underpass", "A dimly lit underground tunnel. You feel claustrophobic.",
                new string[] { "Push through the tunnel", "Retreat" },
                new string[] { "You find a treasure chest, but it’s cursed!", "You retreat and find yourself lost." }, "Exit Room");

            Room exitRoom = new Room("Exit Room", "The final room. You must decide your fate.",
                new string[] { "Exit the game", "Stay and explore further" },
                new string[] { "You exit, victorious and free!", "The world collapses, and you are trapped." }, "");

            bool gameRunning = true;
            while (gameRunning)
            {
                Console.Clear();
                Console.WriteLine($"Your Health: {player.Health}");
                Console.WriteLine($"Current Room: {player.CurrentRoom}");

                switch (player.CurrentRoom)
                {
                    case "Room 1":
                        room1.EnterRoom();
                        room1.ShowChoices();
                        int choice = GetValidChoice(room1.Choices.Length);
                        room1.HandleChoice(choice, player);
                        player.CurrentRoom = (choice == 1) ? "Corridor 7" : "Room 1";
                        break;

                    case "Corridor 7":
                        corridor7.EnterRoom();
                        corridor7.ShowChoices();
                        choice = GetValidChoice(corridor7.Choices.Length);
                        corridor7.HandleChoice(choice, player);
                        if (player.Health <= 0) { gameRunning = false; break; }
                        player.CurrentRoom = (choice == 1) ? "Vault" : (choice == 2) ? "Passageway" : "Room 1";
                        break;

                    case "Vault":
                        vault.EnterRoom();
                        vault.ShowChoices();
                        choice = GetValidChoice(vault.Choices.Length);
                        vault.HandleChoice(choice, player);
                        player.CurrentRoom = (choice == 1) ? "Passageway" : "Room 1";
                        break;

                    case "Passageway":
                        passageway.EnterRoom();
                        passageway.ShowChoices();
                        choice = GetValidChoice(passageway.Choices.Length);
                        passageway.HandleChoice(choice, player);
                        player.CurrentRoom = (choice == 1) ? "Void" : "Vault";
                        break;

                    case "Void":
                        voidRoom.EnterRoom();
                        voidRoom.ShowChoices();
                        choice = GetValidChoice(voidRoom.Choices.Length);
                        voidRoom.HandleChoice(choice, player);
                        player.CurrentRoom = (choice == 1) ? "Area 3" : "Room 1";
                        break;

                    case "Area 3":
                        area3.EnterRoom();
                        area3.ShowChoices();
                        choice = GetValidChoice(area3.Choices.Length);
                        area3.HandleChoice(choice, player);
                        player.CurrentRoom = (choice == 1) ? "Room of Mirrors" : "Void";
                        break;

                    case "Room of Mirrors":
                        roomOfMirrors.EnterRoom();
                        roomOfMirrors.ShowChoices();
                        choice = GetValidChoice(roomOfMirrors.Choices.Length);
                        roomOfMirrors.HandleChoice(choice, player);
                        player.CurrentRoom = (choice == 1) ? "Chamber of Time" : "Area 3";
                        break;

                    case "Chamber of Time":
                        chamberOfTime.EnterRoom();
                        chamberOfTime.ShowChoices();
                        choice = GetValidChoice(chamberOfTime.Choices.Length);
                        chamberOfTime.HandleChoice(choice, player);
                        player.CurrentRoom = (choice == 1) ? "Underpass" : "Room of Mirrors";
                        break;

                    case "Underpass":
                        underpass.EnterRoom();
                        underpass.ShowChoices();
                        choice = GetValidChoice(underpass.Choices.Length);
                        underpass.HandleChoice(choice, player);
                        player.CurrentRoom = (choice == 1) ? "Exit Room" : "Chamber of Time";
                        break;

                    case "Exit Room":
                        exitRoom.EnterRoom();
                        exitRoom.ShowChoices();
                        choice = GetValidChoice(exitRoom.Choices.Length);
                        exitRoom.HandleChoice(choice, player);
                        if (choice == 1)
                        {
                            Console.WriteLine("Congratulations, you finished the game!");
                            gameRunning = false;
                        }
                        break;
                }
            }

            Console.WriteLine("Game Over. Thanks for playing!");
        }

        // Method to ensure the user inputs a valid choice
        static int GetValidChoice(int numChoices)
        {
            int choice = 0;
            while (choice < 1 || choice > numChoices)
            {
                Console.Write("Please choose a valid option: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out choice) && choice >= 1 && choice <= numChoices)
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
            return choice;
        }
    }
}
