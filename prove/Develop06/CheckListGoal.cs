using System;
class ChecklistGoal : Goal
{
    private int requiredTimes;
    private int completedTimes;
    private int perEventPoints;
    private int bonusPoints;

    public ChecklistGoal(string name, int requiredTimes, int perEventPoints, int bonusPoints)
        : base(name)
    {
        this.requiredTimes = requiredTimes;
        this.perEventPoints = perEventPoints;
        this.bonusPoints = bonusPoints;
        this.completedTimes = 0;
    }
    public override void RecordEvent()
    {
        if (!IsComplete)
        {
            completedTimes++;
            Points += perEventPoints;
            Console.WriteLine($"{Name} recorded {completedTimes}/{requiredTimes}. You earned {perEventPoints} points.");

            if (completedTimes >= requiredTimes)
            {
                Points += bonusPoints;
                IsComplete = true;
                Console.WriteLine($"Bonus achieved! You earned an extra {bonusPoints} points.");
            }
        }
        else
        {
            Console.WriteLine($"{Name} has already been completed.");
        }
    }

    public override void DisplayGoal()
    {
        string status = IsComplete ? "[X]" : $"[{completedTimes}/{requiredTimes}]";
        Console.WriteLine($"{status} {Name} - Points: {Points}");
        Console.WriteLine($"This is a checklist goal. Points per event: {perEventPoints}, Bonus Points: {bonusPoints}");
    }
}
