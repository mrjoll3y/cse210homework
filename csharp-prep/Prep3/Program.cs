using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("what is the magic number? ");
        int magic_number = int.Parse(Console.ReadLine());

        int guess = -1;
        
        
        while (guess != magic_number)

        {
            Console.Write("What is your Guess? ");
            guess = int.Parse(Console.ReadLine());
        

             if (guess < magic_number)
            {
                Console.WriteLine("Higher");
                Console.Write("");
            }

            else if (guess > magic_number)
            {
                Console.WriteLine("Lower");
                Console.Write("");
            }
        
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}