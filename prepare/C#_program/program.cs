using System;

public class Program
{
    static void Main(string[] args)
    {
        TaskScheduler scheduler = new TaskScheduler();

        // Load tasks from file (if any)
        scheduler.LoadTasksFromFile();

        // Adding tasks
        scheduler.AddTask("Complete C# tutorial", DateTime.Now.AddHours(1), DateTime.Now.AddMinutes(50));
        scheduler.AddTask("Submit project report", DateTime.Now.AddDays(1), DateTime.Now.AddHours(23));

        // Listing tasks
        scheduler.ListTasks();

        // Simulating marking a task as completed
        scheduler.MarkTaskAsCompleted("Complete C# tutorial");

        // Letting the program run to check reminders every minute
        Console.WriteLine("\nPress Enter to exit...");
        Console.ReadLine();

        // Optionally save tasks before exit
        scheduler.SaveTasksToFile();
    }
}
