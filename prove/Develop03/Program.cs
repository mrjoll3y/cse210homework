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

        // New Story Parts

        private void FindHealingPotion()
        {
            Console.WriteLine("\nYou stumble upon a glowing bottle. It's a healing potion!");
            PlayerHealth += 30;
            Console.WriteLine("Your health is restored! Your health is now: " + PlayerHealth);
            NextPartOfTheStory();
        }

        private void TakeAChance()
        {
            Console.WriteLine("\nYou find a room filled with treasures. But wait... it seems too easy.");
            Console.WriteLine("Do you take the treasures?");
            Console.WriteLine("1. Yes, take everything!");
            Console.WriteLine("2. No, leave the treasures and be cautious.");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\nYou greedily take all the treasure... but a trap is triggered!");
                    PlayerHealth -= 30;
                    Console.WriteLine("You are injured by the trap. Your health is now: " + PlayerHealth);
                    break;
                case "2":
                    Console.WriteLine("\nYou wisely leave the treasures and avoid the trap.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose 1 or 2.");
                    break;
            }

            NextPartOfTheStory();
        }

        private void MeetTheHealer()
        {
            Console.WriteLine("\nYou find an old healer in a dark corner of the dungeon.");
            Console.WriteLine("The healer offers to restore some of your health in exchange for a favor.");
            Console.WriteLine("Do you accept?");
            Console.WriteLine("1. Yes, accept the offer.");
            Console.WriteLine("2. No, decline the offer.");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PlayerHealth += 40;
                    Console.WriteLine("\nThe healer restores your health. Your health is now: " + PlayerHealth);
                    break;
                case "2":
                    Console.WriteLine("\nYou decline the healer's offer and continue on your way.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose 1 or 2.");
                    break;
            }

            NextPartOfTheStory();
        }

        private void FallIntoPit()
        {
            Console.WriteLine("\nYou step forward and suddenly fall into a deep pit!");
            PlayerHealth -= 25;
            Console.WriteLine("You are injured from the fall. Your health is now: " + PlayerHealth);

            if (PlayerHealth <= 0)
            {
                IsGameOver = true;
                Console.WriteLine("You were badly hurt in the fall. Game Over!");
                return;
            }

            NextPartOfTheStory();
        }

        private void EncounterSpider()
        {
            Console.WriteLine("\nA giant spider appears from the shadows!");
            Enemy spider = new Enemy("Giant Spider", 70);
            Combat combat = new Combat(player, spider);
            combat.StartCombat();

            if (PlayerHealth <= 0)
            {
                IsGameOver = true;
                Console.WriteLine("You were defeated by the spider. Game Over!");
                return;
            }

            Console.WriteLine("\nYou defeat the spider and find a hidden passage.");
            NextPartOfTheStory();
        }

        private void HiddenTreasure()
        {
            Console.WriteLine("\nYou discover a hidden alcove and find an ancient treasure chest.");
            PlayerHealth += 20;
            Console.WriteLine("You gain some health from a magical aura surrounding the chest. Your health is now: " + PlayerHealth);
            NextPartOfTheStory();
        }

        private void FriendlyKnight()
        {
            Console.WriteLine("\nA friendly knight offers to help you with your journey.");
            PlayerHealth += 10;
            Console.WriteLine("The knight's assistance restores some of your health. Your health is now: " + PlayerHealth);
            NextPartOfTheStory();
        }
    }
}
