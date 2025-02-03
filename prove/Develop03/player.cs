using System;

namespace CSharpDemo
{
    public class Player : Character
    {
        public Player(string name, int health) : base(name, health) { }

        public override void Attack()
        {
            Console.WriteLine($"{Name} swings their sword!");
        }
    }
}
