using System;

namespace CSharpDemo
{
    public class Game
    {
        private int maxHealth;
        private Player player;

        public Game(int maxHealth, Player player)
        {
            this.maxHealth = maxHealth;
            this.player = player;
        }

        public void Start()
        {
            Console.WriteLine($"Welcome, {player.Name}, to the Adventure Game!");
            Console.WriteLine("Your journey begins now...");
            NextPartOfTheStory();
        }

        private void NextPartOfTheStory()
        {
            Console.WriteLine("\nWhat would you like to do next?");
            Console.WriteLine("1. Venture into the forest");
            Console.WriteLine("2. Rest at the camp");
            Console.WriteLine("3. Visit the village");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    VentureIntoForest();
                    break;
                case "2":
                    RestAtCamp();
                    break;
                case "3":
                    VisitVillage();
                    break;
                default:
                    Console.WriteLine("Invalid choice, please choose again.");
                    NextPartOfTheStory();
                    break;
            }
        }

        private void VentureIntoForest()
        {
            Console.WriteLine("\nYou venture deeper into the forest.");
            Console.WriteLine("Suddenly, a wild wolf appears!");

            CombatWithWolf();

            Console.WriteLine("\nAfter the battle, you find a mysterious cave.");
            Console.WriteLine("Do you want to enter the cave? (Y/N)");
            string choice = Console.ReadLine();

            if (choice.ToUpper() == "Y")
            {
                EnterCave();
            }
            else
            {
                Console.WriteLine("You decide to continue your journey through the forest.");
                NextPartOfTheStory();
            }
        }

        private void RestAtCamp()
        {
            Console.WriteLine("\nYou rest at the camp and recover some health.");
            player.Health += 20;
            if (player.Health > maxHealth) player.Health = maxHealth;  // Prevent exceeding max health
            Console.WriteLine($"Your health is now {player.Health}.");
            NextPartOfTheStory();
        }

        private void VisitVillage()
        {
            Console.WriteLine("\nYou arrive at a small village.");
            Console.WriteLine("The villagers offer you food and shelter.");
            Console.WriteLine("Do you want to accept their offer? (Y/N)");

            string choice = Console.ReadLine();

            if (choice.ToUpper() == "Y")
            {
                Console.WriteLine("You enjoy a warm meal and rest, recovering 30 health.");
                player.Health += 30;
                if (player.Health > maxHealth) player.Health = maxHealth;  // Prevent exceeding max health
            }
            else
            {
                Console.WriteLine("You politely decline and leave the village.");
            }

            Console.WriteLine($"Your health is now {player.Health}.");
            NextPartOfTheStory();
        }

        private void CombatWithWolf()
        {
            Random random = new Random();
            int damage = random.Next(15, 30);  // Wolf deals random damage
            Console.WriteLine($"The wolf attacks! You take {damage} damage.");
            player.Health -= damage;

            if (player.Health <= 0)
            {
                Console.WriteLine("You have been defeated by the wolf.");
                player.SaveStats();
                Environment.Exit(0);  // End the game if health drops to 0 or below
            }

            Console.WriteLine($"Your health is now {player.Health}.");
            NextPartOfTheStory();
        }

        private void EnterCave()
        {
            Console.WriteLine("\nYou enter the cave and find an ancient treasure chest.");
            Console.WriteLine("Do you want to open it? (Y/N)");
            string choice = Console.ReadLine();

            if (choice.ToUpper() == "Y")
            {
                OpenTreasureChest();
            }
            else
            {
                Console.WriteLine("You leave the chest unopened and exit the cave.");
                NextPartOfTheStory();
            }
        }

        private void OpenTreasureChest()
        {
            Random random = new Random();
            int healthRestored = random.Next(20, 50);
            Console.WriteLine($"You open the chest and find a healing potion! It restores {healthRestored} health.");
            player.Health += healthRestored;
            if (player.Health > maxHealth) player.Health = maxHealth;  // Prevent exceeding max health
            Console.WriteLine($"Your health is now {player.Health}.");

            NextPartOfTheStory();
        }
    }
}
