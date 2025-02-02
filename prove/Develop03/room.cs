using System;

public class Room
{
    public string Name;
    public string Description;

    public Room(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void EnterRoom()
    {
        Console.WriteLine("You have entered: " + Name);
        Console.WriteLine(Description);
    }
}
