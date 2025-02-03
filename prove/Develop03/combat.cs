using System;

namespace CSharpDemo
{
    public class Combat
    {
        public Player Player { get; set; }
        public Enemy Enemy { get; set; }

        public Combat(Player player, Enemy enemy)
        {
            Player = player;
            Enemy = enemy;
        }

        public void StartCombat()
        {
            // Simulating combat
            Player.Attack();
            Enemy.Attack();
        }
    }
}
