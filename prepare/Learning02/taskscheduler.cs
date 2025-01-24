using System;
using System;
using System.Collections.Generic;
using System.IO;

    public class TaskScheduler
    {
        private List<Task> tasks = new List<Task>();

        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

        public void ShowTasks()
        {
            foreach (var task in tasks)
            {
                task.DisplayTask();
            }
        }

        public void SaveTasksToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var task in tasks)
                {
                    writer.WriteLine($"{task.Title}|{task.DueDate}|{(task is ReminderTask ? ((ReminderTask)task).ReminderMessage : "No Reminder")}");
                }
            }
        }

        public void LoadTasksFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found.");
                return;
            }

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        ReminderTask task = new ReminderTask
                        {
                            Title = parts[0],
                            DueDate = DateTime.Parse(parts[1]),
                            ReminderMessage = parts[2]
                        };
                        AddTask(task);
                    }
                }
            }
        }
    }

