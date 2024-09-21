using System;

class Program
{
    static void Main(string[] args)
    {
        welcome_message();

        string user_name = user_prompt();
        int fave = fave_of_user();
        int squared = square(fave);
        Result(user_name, squared);
    }

    static void welcome_message()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string user_prompt()
    {
        Console.Write("What is your name? ");
        string name = Console.ReadLine();
        return name;
    }
    static int fave_of_user()
    {
        Console.Write("What is your favorite number? ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }
    static int square(int number)
    {
        int square = number * number;
        return square;
    }
    static void Result(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}!");
    }

}