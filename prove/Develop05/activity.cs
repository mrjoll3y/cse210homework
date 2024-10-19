using System;
public abstract class MindfulnessActivity
{
    protected string activityName;
    protected string description;
    protected int duration;

    public void StartActivity()
    {
        Console.WriteLine($"Starting {activityName}...");
        Console.WriteLine(description);
        Console.Write("Enter the duration (in seconds): ");
        duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready...");
        Thread.Sleep(3000); // Wait 3 seconds
    }

    public void EndActivity()
    {
        Console.WriteLine("Great job! You completed the activity.");
        Console.WriteLine($"You completed {activityName} for {duration} seconds.");
        Thread.Sleep(3000); // Wait before ending
    }
    protected bool PauseWithAnimation(int seconds)
{
    for (int i = seconds; i > 0; i--)
    {
        if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Q)
        {
            Console.WriteLine("\nActivity canceled.");
            return false; // Return false to indicate the activity was canceled
        }

        Console.Write($"\r{i} seconds remaining... Press 'Q' to cancel.");
        Thread.Sleep(1000); // 1-second delay for countdown
    }
    Console.WriteLine();
    return true; // Return true if the pause completes without cancellation
}


    public abstract void PerformActivity();
}
