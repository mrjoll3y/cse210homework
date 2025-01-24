using System;

public class Task
{
    public string Name { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime ReminderTime { get; set; }
    public bool IsCompleted { get; set; }

    public Task(string name, DateTime dueDate, DateTime reminderTime)
    {
        Name = name;
        DueDate = dueDate;
        ReminderTime = reminderTime;
        IsCompleted = false;
    }

    public void CompleteTask()
    {
        IsCompleted = true;
        Console.WriteLine($"Task '{Name}' completed!");
    }
}
