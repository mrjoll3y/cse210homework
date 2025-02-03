using System;

namespace CSharpDemo
{
    public class Enemy : Character
    {
        public Enemy(string name, int health) : base(name, health) { }

        public override void Attack()
        {
            Console.WriteLine($"{Name} lunges at you!");
        }
    }
}
