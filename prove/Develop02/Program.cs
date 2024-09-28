using System;
public class Program
{
    static List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "What are you grateful for right now?",
        "Describe a moment when you felt at peace today",
        "What was the most surprising thing that happened today?",
        "Write about a goal you want to achieve this week?",
        "What is something new you learned today?",
        "What was the highlight of your day?",
        "How did you practice kindness today?",
        "Describe one challenge you faced and how you overcame it.",
        "What is something you wish you had more time for today",
        "What inspired you today?",
        "What is a piece of advice you received recently?",
        "What is something you did today that made you proud?",
        "How did you take care of yourself today?",
        "Write about one person who positively influenced your day.",
        "What is one thing you are looking forward to tomorrow?",
        "If today was a chapter in your autobiography, what would its title be?",
        "Describe a conversation that had a lasting impact on you today.",
        "What did you do today that helped someone else?",
        "Reflect on a small win or achievement from today.",
        "What iss something you wish you had said to someone today?",
        "How did you manage stress or difficult emotions today?",
        "What would you do differently if you could relive today?",
        "What is something you want to remember about today?",
        "Describe one thing that made you laugh today.",
        "What was the most peaceful moment of your day?",
        "What is something you accomplished today, big or small?",
        "What is one thing you are letting go of today?",
        "How did you express creativity today?",
        "What is a dream or goal you are currently working toward?"
    };

    static void Main(string[] args)
    {
        Journal journal = new Journal();
        string option = "";

        while (option != "5")
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateNewEntry(journal);
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;
            }
        }
    }

    // Create a new journal entry based on a random prompt
    static void CreateNewEntry(Journal journal)
    {
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine(prompt);
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        journal.AddEntry(new Entry(prompt, response));
    }

    // Save the journal to a file specified by the user
    static void SaveJournal(Journal journal)
    {
        Console.Write("Enter the filename to save the journal: ");
        string filename = Console.ReadLine();
        journal.SaveJournal(filename);
    }

    // Load the journal from a file specified by the user
    static void LoadJournal(Journal journal)
    {
        Console.Write("Enter the filename to load the journal: ");
        string filename = Console.ReadLine();
        journal.LoadJournal(filename);
    }
}