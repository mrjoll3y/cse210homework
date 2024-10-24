using System;
abstract class Goal
{
    public string Name { get; private set; }
    public int Points { get; protected set; }
    public bool IsComplete { get; protected set; }

    public Goal(string name)
    {
        Name = name;
        IsComplete = false;
    }
    public abstract void RecordEvent();
    public virtual void DisplayGoal()
    {
        string status = IsComplete ? "[X]" : "[ ]";
        Console.WriteLine($"{status} {Name} - Points: {Points}");
    }
}



