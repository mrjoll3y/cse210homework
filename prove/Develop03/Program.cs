using System;
public class Program
{
    
    private static List<Scripture> scriptures = new List<Scripture>
    {
        new Scripture(new Reference("1 Nephi", 3, 7), "I will go and do the things which the Lord hath commanded."),
        new Scripture(new Reference("2 Nephi", 2, 25), "Adam fell that men might have joy."),
        new Scripture(new Reference("Mosiah", 2, 17), "When ye are in the service of your fellow beings ye are only in the service of your God."),
        new Scripture(new Reference("Alma", 32, 21), "Faith is not to have a perfect knowledge of things; therefore if ye have faith ye hope for things which are not seen, which are true."),
        new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
        new Scripture(new Reference("3 Nephi", 12, 48), "Therefore I would that ye should be perfect even as I, or your Father who is in heaven is perfect."),
        new Scripture(new Reference("1 Nephi", 19, 23), "I did liken all scriptures unto us, that it might be for our profit and learning."),
        new Scripture(new Reference("Mosiah", 3, 19), "For the natural man is an enemy to God."),
        new Scripture(new Reference("Alma", 37, 37), "Counsel with the Lord in all thy doings."),
        new Scripture(new Reference("Mosiah", 4, 30), "Watch yourselves, and your thoughts, and your words, and your deeds."),
        new Scripture(new Reference("Alma", 41, 10), "Wickedness never was happiness."),
        new Scripture(new Reference("Mosiah", 2, 41), "Consider on the blessed and happy state of those that keep the commandments of God."),
        new Scripture(new Reference("Proverbs", 3, 5), "Trust in the Lord with all thine heart; and lean not unto thine own understanding."),
        new Scripture(new Reference("Matthew", 22, 37), "Thou shalt love the Lord thy God with all thy heart, and with all thy soul, and with all thy mind."),
        new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
        new Scripture(new Reference("Mosiah", 2, 17, 18), "And behold, I tell you these things that ye may learn wisdom; that ye may learn that when ye are in the service of your fellow beings ye are only in the service of your God. And behold, I tell you the truth, that ye must serve him with all your heart, mind, and strength."),
        new Scripture(new Reference("Alma", 34, 32, 33), "This life is the time for men to prepare to meet God; yea, behold the day of this life is the day for men to perform their labors. And now, as ye are called to the labor, ye are called to prepare for the day of the Lord.")
        };

    public static void Main(string[] args)
    {
        Random random = new Random();
        var scripture = scriptures[random.Next(scriptures.Count)]; 

       
        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.Ref); 
            Console.WriteLine(scripture.GetDisplayedText()); 
            Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");

            var input = Console.ReadLine();
            if (input?.ToLower() == "quit")
                break;

           
            scripture.HideRandomWords();
        }

        Console.Clear();
        Console.WriteLine("All words are hidden. Program ended.");
    }
}