using System;

    class Program
    {
        static void Main(string[] args)
        {
            taskscheduler scheduler = new taskscheduler();
            string filePath = "tasks.txt";

            // Add a task dynamically
            Console.WriteLine("Enter task title:");
            string title = Console.ReadLine();
            Console.WriteLine("Enter due date (yyyy-mm-dd):");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter reminder message:");
            string reminderMessage = Console.ReadLine();

            remindertask newTask = new remindertask
            {
                Title = title,
                DueDate = dueDate,
                ReminderMessage = reminderMessage
            };

            scheduler.AddTask(newTask);
            scheduler.ShowTasks();

            // Save tasks to file
            scheduler.SaveTasksToFile(filePath);
            Console.WriteLine("Tasks saved to file.");

            // Load tasks from file and display them
            scheduler.LoadTasksFromFile(filePath);
            Console.WriteLine("Loaded tasks:");
            scheduler.ShowTasks()