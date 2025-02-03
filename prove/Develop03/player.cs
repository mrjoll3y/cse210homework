namespace CSharpDemo
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public Player(string name, int health)
        {
            Name = name;
            Health = health;
        }
    }
}
