using System;
public class ListingActivity : MindfulnessActivity
{
    private string[] prompts = {
        "List people you appreciate.",
        "List your personal strengths.",
        "List people you helped this week.",
        "List your personal heroes."
    };

    public ListingActivity()
    {
        activityName = "Listing Activity";
        description = "This activity will help you reflect on positive things by listing them.";
    }

   public override void PerformActivity()
    {
        StartActivity();

        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Length)];
        Console.WriteLine(prompt);

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("Enter an item: ");
            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Q)
            {
                Console.WriteLine("\nActivity canceled.");
                return; // Cancel activity if user presses 'Q'
            }

            string item = Console.ReadLine();
            items.Add(item);
        }

        Console.WriteLine($"You listed {items.Count} items.");
        EndActivity();
    }

}
