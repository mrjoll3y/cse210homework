using System;
public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
    {
        activityName = "Breathing Exercise";
        description = "This activity will help you relax by guiding you through deep breathing.";
    }
    public override void PerformActivity()
{
    StartActivity();

    int halfDuration = duration / 2;
    for (int i = 0; i < halfDuration; i++)
    {
        Console.WriteLine("Breathe in...");
        if (!PauseWithAnimation(3)) return; // Cancel activity if user presses 'Q'
        
        Console.WriteLine("Breathe out...");
        if (!PauseWithAnimation(3)) return; // Cancel activity if user presses 'Q'
    }

    EndActivity();
}

}
