namespace TextAdventureGame
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; } = 100;  // Default health
        public string CurrentRoom { get; set; } = "Room 1";  // Starting room

        public Player(string name)
        {
            Name = name;
        }
    }
}
