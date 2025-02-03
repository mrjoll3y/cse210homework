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
            PlayerHealth -= 10;

            if (PlayerHealth <= 0)
            {
                IsGameOver = true;
                Console.WriteLine("You were injured too badly and collapsed. Game Over!");
                return;
            }

            EncounterEnemy();
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

            if (PlayerHealth <= 0)
            {
                IsGameOver = true;
                Console.WriteLine("You have been defeated by the goblin. Game Over!");
                return;
            }

            Console.WriteLine("\nYou defeated the goblin, but there are more dangers ahead...");
            Console.WriteLine("Your health is now: " + PlayerHealth);

            NextPartOfTheStory();
        }

        private void NextPartOfTheStory()
        {
            Console.WriteLine("\nYou find a door leading deeper into the dungeon.");
            Console.WriteLine("You hear eerie sounds coming from the other side. What will you do?");
            Console.WriteLine("1. Open the door and enter.");
            Console.WriteLine("2. Leave the dungeon and try to find a safe exit.");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    OpenDoor();
                    break;
                case "2":
                    LeaveDungeon();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose 1 or 2.");
                    break;
            }
        }

        private void OpenDoor()
        {
            Console.WriteLine("\nYou open the door and step into a dark corridor.");
            Console.WriteLine("The air grows colder, and you hear a distant growl.");
            PlayerHealth -= 15;

            if (PlayerHealth <= 0)
            {
                IsGameOver = true;
                Console.WriteLine("You succumb to the cold and injury. Game Over!");
                return;
            }

            Console.WriteLine("You manage to escape the cold and continue deeper into the dungeon.");
            EncounterDragon();
        }

        private void LeaveDungeon()
        {
            Console.WriteLine("\nYou decide that the dungeon is too dangerous.");
            Console.WriteLine("You find an exit and leave the dungeon safely.");
            Console.WriteLine("But the treasure remains untouched, and the adventure ends.");
            IsGameOver = true;
        }

        private void EncounterDragon()
        {
            Console.WriteLine("\nSuddenly, a massive dragon appears in front of you!");
            Enemy dragon = new Enemy("Dragon", 100);
            Combat combat = new Combat(player, dragon);
            combat.StartCombat();

            if (PlayerHealth <= 0)
            {
                IsGameOver = true;
                Console.WriteLine("You were defeated by the dragon. Game Over!");
                return;
            }

            Console.WriteLine("\nAgainst all odds, you slay the dragon!");
            Console.WriteLine("You've found the treasure, but the dungeon is collapsing!");
            EscapeDungeon();
        }

        private void EscapeDungeon()
        {
            Console.WriteLine("\nThe dungeon begins to collapse around you!");
            Console.WriteLine("You race to the exit, but the rocks are falling faster!");
            PlayerHealth -= 20;

            if (PlayerHealth <= 0)
            {
                IsGameOver = true;
                Console.WriteLine("You didn't make it out in time. Game Over!");
                return;
            }

            Console.WriteLine("\nYou manage to escape the dungeon just as it collapses behind you.");
            Console.WriteLine("You've found the treasure, survived the dungeon, and lived to tell the tale!");
            IsGameOver = true;
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
