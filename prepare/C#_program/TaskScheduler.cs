using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;

public class TaskScheduler
{
    private List<Task> tasks = new List<Task>();
    private Timer reminderTimer;

    public TaskScheduler()
    {
        reminderTimer = new Timer(60000); // Check every minute
        reminderTimer.Elapsed += CheckReminders;
        reminderTimer.Start();
    }

    public void AddTask(string taskName, DateTime dueDate, DateTime reminderTime)
    {
        tasks.Add(new Task(taskName, dueDate, reminderTime));
        Console.WriteLine($"Added task: {taskName}, due by {dueDate}, reminder at {reminderTime}");
    }

    public void ListTasks()
    {
        foreach (var task in tasks)
        {
            string status = task.IsCompleted ? "Completed" : "Pending";
            Console.WriteLine($"{task.Name} - Due: {task.DueDate} - Reminder: {task.ReminderTime} - Status: {status}");
        }
    }

    public void MarkTaskAsCompleted(string taskName)
    {
        var task = tasks.FirstOrDefault(t => t.Name == taskName);
        if (task != null && !task.IsCompleted)
        {
            task.CompleteTask();
        }
        else
        {
            Console.WriteLine($"Task '{taskName}' not found or already completed.");
        }
    }

    private void CheckReminders(object sender, ElapsedEventArgs e)
    {
        foreach (var task in tasks)
        {
            if (!task.IsCompleted && DateTime.Now >= task.ReminderTime)
            {
                Console.WriteLine($"Reminder: {task.Name} is due! [Reminder time: {task.ReminderTime}]");
                task.ReminderTime = DateTime.MaxValue; // Stop further reminders for this task
            }
        }
    }

    // Optional: Save tasks to a file
    public void SaveTasksToFile()
    {
        using (StreamWriter writer = new StreamWriter("tasks.txt"))
        {
            foreach (var task in tasks)
            {
                writer.WriteLine($"{task.Name}|{task.DueDate}|{task.ReminderTime}|{task.IsCompleted}");
            }
        }
    }

    // Optional: Load tasks from a file
    public void LoadTasksFromFile()
    {
        if (File.Exists("tasks.txt"))
        {
            foreach (var line in File.ReadLines("tasks.txt"))
            {
                var parts = line.Split('|');
                string taskName = parts[0];
                DateTime dueDate = DateTime.Parse(parts[1]);
                DateTime reminderTime = DateTime.Parse(parts[2]);
                bool isCompleted = bool.Parse(parts[3]);
                tasks.Add(new Task(taskName, dueDate, reminderTime) { IsCompleted = isCompleted });
            }
        }
    }
}
