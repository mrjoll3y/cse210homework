using System;

public class Player
{
    public string Name;
    public int Health;
    public string CurrentRoom;

    public Player(string name)
    {
        Name = name;
        Health = 100;  // Starting health
        CurrentRoom = "Starting Room"; // Default room
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0) Health = 0;
    }
}
