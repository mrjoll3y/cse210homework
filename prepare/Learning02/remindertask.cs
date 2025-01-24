using System;


// ReminderTask.cs

    public class ReminderTask : Task
    {
        public string ReminderMessage { get; set; }

        public override void DisplayTask()
        {
            Console.WriteLine($"Task: {Title}\nDue Date: {DueDate}\nReminder: {ReminderMessage}\n");
        }
    }