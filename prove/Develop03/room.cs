namespace TextAdventureGame
{
    public class Room
    {
        // The name of the room (e.g., "Room 1", "Vault")
        public string Name { get; set; }

        // A description of what the room looks like or the atmosphere
        public string Description { get; set; }

        // A list of choices available to the player in this room
        public string[] Choices { get; set; }

        // A list of results for each choice the player makes
        public string[] Results { get; set; }

        // The name of the next room that the player can enter after making a choice
        public string NextRoom { get; set; }

        // Constructor to initialize the room properties
        public Room(string name, string description, string[] choices, string[] results, string nextRoom)
        {
            Name = name;
            Description = description;
            Choices = choices;
            Results = results;
            NextRoom = nextRoom;
        }

        // Method to display the description of the room to the player
        public void EnterRoom()
        {
            Console.WriteLine(Name);          // Display the room's name
            Console.WriteLine(Description);   // Display the room's description
        }

        // Method to display all available choices to the player
        public void ShowChoices()
        {
            Console.WriteLine("What will you do?");
            for (int i = 0; i < Choices.Length; i++)
            {
                // Display each choice option, numbered starting from 1
                Console.WriteLine($"{i + 1}. {Choices[i]}");
            }
        }
    

        // Method to handle the player's choice, displaying the corresponding result
        public void HandleChoice(int choice, Player player)
        {
            // Ensure the choice is valid
            if (choice < 1 || choice > Choices.Length)
            {
                Console.WriteLine("Invalid choice. Try again.");
                return;
            }

            // Display the result of the player's choice
            Console.WriteLine(Results[choice - 1]);

            // Adjust player health or other variables based on the choice's outcome
            if (choice == 1 && Name == "Vault")  // Example of specific choice impact
            {
                // Decrease health if specific choice leads to a trap or danger
                player.Health -= 10;
                Console.WriteLine("You lost some health.");
            }
            else if (choice == 2 && Name == "Room of Mirrors")  // Example of beneficial outcome
            {
                player.Health += 10;
                Console.WriteLine("You feel rejuvenated and gain some health.");
            }

            // Logic to move the player to the next room (if applicable)
            if (NextRoom != "")
            {
                player.CurrentRoom = NextRoom;
            }
        }
    }
}
