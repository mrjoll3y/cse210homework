namespace TextAdventureGame
{
    public class Room
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Choices { get; set; }
        public string[] Results { get; set; }
        public string NextRoom { get; set; }

        public Room(string name, string description, string[] choices, string[] results, string nextRoom)
        {
            Name = name;
            Description = description;
            Choices = choices;
            Results = results;
            NextRoom = nextRoom;
        }

        // Display the room description
        public void EnterRoom()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Description);
        }

        // Show choices for the player
        public void ShowChoices()
        {
            Console.WriteLine("Choose an action:");
            for (int i = 0; i < Choices.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Choices[i]}");
            }
        }

        // Handle the player's choice and update the health or room
        public void HandleChoice(int choice, Player player)
        {
            if (choice < 1 || choice > Choices.Length)
            {
                Console.WriteLine("Invalid choice. Try again.");
                return;
            }

            Console.WriteLine(Results[choice - 1]);
