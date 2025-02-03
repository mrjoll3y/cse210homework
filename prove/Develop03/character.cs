using System;

namespace CSharpDemo
{
    // Abstract class for all characters
    public abstract class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public Character(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public abstract void Attack();
    }
}
