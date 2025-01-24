using system;
// Task.cs


    public abstract class Task
    {
        public string Title { get; set; }
        public DateTime DueDate { get; set; }

        public abstract void DisplayTask();
    }

