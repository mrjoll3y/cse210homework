using System;
public class ReflectionActivity : MindfulnessActivity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something selfless."
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you feel when it was complete?",
        "What could you learn from this experience?"
    };

    public ReflectionActivity()
    {
        activityName = "Reflection Activity";
        description = "This activity will help you reflect on moments of strength and resilience.";
    }
    public override void PerformActivity()
{
    StartActivity();

    Random rand = new Random();
    string prompt = prompts[rand.Next(prompts.Length)];
    Console.WriteLine(prompt);

    int timePerQuestion = duration / questions.Length;
    foreach (string question in questions)
    {
        Console.WriteLine(question);
        if (!PauseWithAnimation(timePerQuestion)) return; // Cancel activity if user presses 'Q'
    }

    EndActivity();
}


}
