using System;
using System.Collections.Generic;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int totalScore = 0;

    static void Main(string[] args)
    {
        bool exitProgram = false;
        
        while (!exitProgram)
        {
            Console.WriteLine("\n--- Goal Tracker Menu ---");
            Console.WriteLine("1. Add a new goal");
            Console.WriteLine("2. Record progress on a goal");
            Console.WriteLine("3. View all goals");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");
            
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddGoal();
                    break;
                case "2":
                    RecordProgress();
                    break;
                case "3":
                    ViewGoals();
                    break;
                case "4":
                    exitProgram = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please select again.");
                    break;
            }
        }

        Console.WriteLine("\nThank you for using the Goal Tracker!");
    }

    static void AddGoal()
    {
        Console.WriteLine("\nWhat type of goal would you like to add?");
        Console.WriteLine("1. Simple Goal (One-time achievement)");
        Console.WriteLine("2. Eternal Goal (Ongoing, never complete)");
        Console.WriteLine("3. Checklist Goal (Achieve multiple times for completion)");
        Console.Write("Select goal type: ");
        
        string goalType = Console.ReadLine();
        Console.Write("Enter the name of your goal: ");
        string goalName = Console.ReadLine();

        switch (goalType)
        {
            case "1":
                Console.Write("Enter the points awarded for completing this goal: ");
                int simplePoints = int.Parse(Console.ReadLine());
                goals.Add(new SimpleGoal(goalName, simplePoints));
                break;
                
            case "2":
                Console.Write("Enter the points awarded each time this goal is achieved: ");
                int eternalPoints = int.Parse(Console.ReadLine());
                goals.Add(new EternalGoal(goalName, eternalPoints));
                break;
                
            case "3":
                Console.Write("Enter the number of times needed to complete this goal: ");
                int requiredTimes = int.Parse(Console.ReadLine());
                Console.Write("Enter the points awarded each time this goal is achieved: ");
                int checklistPoints = int.Parse(Console.ReadLine());
                Console.Write("Enter the bonus points awarded upon full completion: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(goalName, requiredTimes, checklistPoints, bonusPoints));
                break;
                
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
        
        Console.WriteLine("Goal added successfully!");
    }

    static void RecordProgress()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("You have no goals to record progress on.");
            return;
        }

        Console.WriteLine("\nSelect a goal to record progress:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Name}");
        }
        
        Console.Write("Enter the number of the goal: ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            goals[goalIndex].RecordEvent();
            totalScore += goals[goalIndex].Points;
            Console.WriteLine($"Total Score: {totalScore} points");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    static void ViewGoals()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("\nYou have no goals to view.");
            return;
        }

        Console.WriteLine("\nYour goals:");
        foreach (var goal in goals)
        {
            goal.DisplayGoal();
        }

        Console.WriteLine($"Total Score: {totalScore} points");
    }
}
