using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Team Lead";
        job1._company = "Walmart";
        job1._yearStart = "2023";
        job1._yearLast = "2026";

        Job job2 = new Job();
        job2._jobTitle = "Team Lead / Trainer";
        job2._company = "Chick-fil-A";
        job2._yearStart = "2020";
        job2._yearLast = "2022";

        Resume myResume = new Resume();
        myResume._name = "Callen Jolley";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
    
}