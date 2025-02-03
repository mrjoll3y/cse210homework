namespace CSharpDemo
{
    public class Combat
    {
        private Player player;
        private Enemy enemy;

        public Combat(Player player, Enemy enemy)
        {
            this.player = player;
            this.enemy = enemy;
        }

        public void StartCombat()
        {
            Console.WriteLine($"{player.Name} faces off against {enemy.Name}!");

            while (player.Health > 0 && enemy.Health > 0)
            {
                // Player turn
                Console.WriteLine($"{player.Name}'s Health: {player.Health}, {enemy.Name}'s Health: {enemy.Health}");
                Console.WriteLine("Choose your action: ");
                Console.WriteLine("1. Attack");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    int damage = new Random().Next(10, 20);  // Random damage for simplicity
                    Console.WriteLine($"{player.Name} attacks and deals {damage} damage to {enemy.Name}!");
                    enemy.TakeDamage(damage);
                }

                if (enemy.Health <= 0)
                {
                    Console.WriteLine($"{enemy.Name} has been defeated!");
                    break;
                }

                // Enemy turn
                int enemyDamage = new Random().Next(5, 15);  // Random damage for simplicity
                Console.WriteLine($"{enemy.Name} attacks and deals {enemyDamage} damage to {player.Name}!");
                player.Health -= enemyDamage;

                if (player.Health <= 0)
                {
                    Console.WriteLine($"{player.Name} has been defeated!");
                    break;
                }
            }
        }
    }
}
