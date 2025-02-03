using System;
using System.IO;

namespace CSharpDemo
{
    public class Game
    {
        public int PlayerHealth { get; set; }
        public bool IsGameOver { get; set; }
        private string filePath = "playerStats.txt";
        private Player player;

        public Game(int startingHealth, Player player)
        {
            PlayerHealth = startingHealth;
            this.player = player;
            IsGameOver = false;
        }

        public void Start()
        {
            DisplayIntro();

            while (!IsGameOver)
            {
                DisplayStory();
                PresentChoices();
            }

            WritePlayerStatsToFile();
        }

        private void DisplayIntro()
        {
            Console.WriteLine("Welcome to the Dungeon Adventure!");
            Console.WriteLine("You are a hero venturing into a dark dungeon to find a lost treasure.");
            Console.WriteLine("Good luck, and choose wisely!\n");
        }

        private void DisplayStory()
        {
            Console.WriteLine("\nYou are standing in front of a mysterious dungeon entrance.");
            Console.WriteLine("The air is thick with anticipation, and you can hear faint noises from within.");
            Console.WriteLine("What will you do next?");
        }

        private void PresentChoices()
        {
            Console.WriteLine("\n1. Enter the dungeon.");
            Console.WriteLine("2. Run away.");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    EnterDungeon();
                    break;
                case "2":
                    RunAway();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose 1 or 2.");
                    break;
            }
        }

        private void EnterDungeon()
        {
            Console.WriteLine("\nYou bravely step into the dungeon...");
            // Simulate some damage for adventure risk
            PlayerHealth -= 10;

            if (PlayerHealth <= 0)
            {
                IsGameOver = true;
                Console.WriteLine("You were injured too badly and collapsed. Game Over!");
            }
            else
            {
                // Player encounters enemy in the dungeon
                EncounterEnemy();
            }
        }

        private void RunAway()
        {
            Console.WriteLine("\nYou run away, too scared to face the dungeon. Game Over!");
            IsGameOver = true;
        }

        private void EncounterEnemy()
        {
            Console.WriteLine("\nYou encounter a fierce goblin in the dungeon!");
            Enemy goblin = new Enemy("Goblin", 50);
            Combat combat = new Combat(player, goblin);
            combat.StartCombat();

            Console.WriteLine("\nYou defeated the goblin, but there are more dangers ahead...");
            Console.WriteLine("Your health is now: " + PlayerHealth);
        }

        private void WritePlayerStatsToFile()
        {
            File.WriteAllText(filePath, $"Player Health: {PlayerHealth}\n");

            if (File.Exists(filePath))
            {
                string playerData = File.ReadAllText(filePath);
                Console.WriteLine("\nPlayer Stats from file:");
                Console.WriteLine(playerData);
            }
        }
    }
}
