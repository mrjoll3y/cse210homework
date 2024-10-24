using System;
class SimpleGoal : Goal
{
    private int completionPoints;
    public SimpleGoal(string name, int completionPoints) : base(name)
    {
        this.completionPoints = completionPoints;
    }
    public override void RecordEvent()
    {
        if (!IsComplete)
        {
            Points += completionPoints;
            IsComplete = true;
            Console.WriteLine($"{Name} completed! You earned {completionPoints} points.");
        }
        else
        {
            Console.WriteLine($"{Name} has already been completed.");
        }
    }
    public override void DisplayGoal()
    {
        base.DisplayGoal();
        Console.WriteLine($"This is a simple goal. Completion Points: {completionPoints}");
    }
}
