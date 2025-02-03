using System;

namespace CSharpDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the player character
            Player player = new Player("Hero", 100);

            // Create the game and start it
            Game game = new Game(100, player);
            game.Start();

            // End of the game message
            Console.WriteLine("\nThe game has ended. Check the playerStats.txt file for your final stats.");
        }
    }
}
