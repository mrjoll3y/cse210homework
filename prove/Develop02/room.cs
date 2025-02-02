namespace TextAdventureGame
{
    public class Room
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Choices { get; set; }
        public string[] Consequences { get; set; }
        public string NextRoom { get; set; }
        public string ItemFound { get; set; }
        public bool RequiresItem { get; set; }
        public bool RequiresStrength { get; set; }
        public bool RequiresIntelligence { get; set; }

        public Room(string name, string description, string[] choices, string[] consequences, string nextRoom, string itemFound = "", bool requiresItem = false, bool requiresStrength = false, bool requiresIntelligence = false)
        {
            Name = name;
            Description = description;
            Choices = choices;
            Consequences = consequences;
            NextRoom = nextRoom;
            ItemFound = itemFound;
            RequiresItem = requiresItem;
            RequiresStrength = requiresStrength;
            RequiresIntelligence = requiresIntelligence;
        }

        public void EnterRoom()
        {
            Console.WriteLine($"{Name}: {Description}");
        }

        public void ShowChoices()
        {
            Console.WriteLine("What would you like to do?");
            for (int i = 0; i < Choices.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Choices[i]}");
            }
        }

        public void HandleChoice(int choice, Player player)
        {
            Console.WriteLine(Consequences[choice - 1]);

            // Consequences for stats
            if (RequiresStrength && player.Strength < 15)
            {
                player.Health -= 10;
                Console.WriteLine("Your strength wasn't enough. You lose 10 health.");
            }

            if (RequiresIntelligence && player.Intelligence < 12)
            {
                player.Health -= 5;
                Console.WriteLine("You couldn't solve the puzzle. You lose 5 health.");
            }

            if (RequiresItem && !player.Inventory.Contains(ItemFound))
            {
                player.Health -= 15;
                Console.WriteLine("You need the right item to proceed. You lose 15 health.");
            }

            if (!string.IsNullOrEmpty(ItemFound))
            {
                Console.WriteLine($"You found a {ItemFound}!");
                player.AddItem(ItemFound);
            }
        }
    }
}
