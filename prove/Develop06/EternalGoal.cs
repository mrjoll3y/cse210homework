using System;
class EternalGoal : Goal
{
    private int perEventPoints;
    public EternalGoal(string name, int perEventPoints) : base(name)
    {
        this.perEventPoints = perEventPoints;
    }
    public override void RecordEvent()
    {
        Points += perEventPoints;
        Console.WriteLine($"{Name} recorded! You earned {perEventPoints} points.");
    }
    public override void DisplayGoal()
    {
        base.DisplayGoal();
        Console.WriteLine($"This is an eternal goal. Points per event: {perEventPoints}");
    }
}
