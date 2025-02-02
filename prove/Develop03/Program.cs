using System;

class Program
{
    static void Main()
    {
        // Introduction
        Console.WriteLine("Welcome to the Text Adventure Game!");
        Console.Write("Enter your character's name: ");
        string playerName = Console.ReadLine();

        // Create player instance
        Player player = new Player(playerName);

        // Create rooms for the adventure
        Room startRoom = new Room("Starting Room", "You are in a small room. There's a door to the north.");
        Room forest = new Room("Forest", "You stand in a dense forest, the path splits ahead.");

        // Game loop
        bool gameRunning = true;
        while (gameRunning)
        {
            Console.WriteLine("\nYour Health: " + player.Health);
            Console.WriteLine("Current Room: " + player.CurrentRoom);

            // Handle player's room and decisions
            if (player.CurrentRoom == "Starting Room")
            {
                startRoom.EnterRoom();
                Console.WriteLine("Do you want to go north? (y/n)");
                string choice = Console.ReadLine().ToLower();

                if (choice == "y")
                {
                    player.CurrentRoom = "Forest";  // Move to the forest
                }
                else
                {
                    Console.WriteLine("You choose to stay in the room.");
                }
            }
            else if (player.CurrentRoom == "Forest")
            {
                forest.EnterRoom();
                Console.WriteLine("Do you want to fight a monster? (y/n)");
                string choice = Console.ReadLine().ToLower();

                if (choice == "y")
                {
                    Console.WriteLine("A monster attacks!");
                    player.TakeDamage(20); // Player takes damage
                    if (player.Health == 0)
                    {
                        Console.WriteLine("You have died. Game Over!");
                        gameRunning = false;
                    }
                }
                else
                {
                    Console.WriteLine("You decide to explore the forest.");
                }

                // Option to leave the game
                Console.WriteLine("Do you want to quit the game? (y/n)");
                string quitChoice = Console.ReadLine().ToLower();
                if (quitChoice == "y")
                {
                    gameRunning = false;
                }
            }
        }

        Console.WriteLine("Thank you for playing!");
    }
}
