namespace TextAdventureGame
{
    public class Room
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Choices { get; set; }
        public string[] Consequences { get; set; }
        public string NextRoom { get; set; }

        public Room(string name, string description, string[] choices, string[] consequences, string nextRoom)
        {
            Name = name;
            Description = description;
            Choices = choices;
            Consequences = consequences;
            NextRoom = nextRoom;
        }

        // Displays the room's description
        public void EnterRoom()
        {
            Console.WriteLine($"{Name}: {Description}");
        }

        // Displays the choices for the player
        public void ShowChoices()
        {
            Console.WriteLine("What would you like to do?");
            for (int i = 0; i < Choices.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Choices[i]}");
            }
        }

        // Handles the consequences of the player's choice
        public void HandleChoice(int choice, Player player)
        {
            // Print the consequence of the player's choice
            Console.WriteLine(Consequences[choice - 1]);

            // Apply consequences, like changing the player's health
            if (choice == 1)
            {
                player.Health -= 10; // Example: Losing health on the first choice
            }
            else if (choice == 2)
            {
                player.Health += 5; // Example: Gaining health on the second choice
            }

            // If health is 0 or below, game ends
            if (player.Health <= 0)
            {
                Console.WriteLine("You have died. Game Over.");
            }
        }
    }
}
