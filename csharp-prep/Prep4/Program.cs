using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        
        int number_input = -1;
        while (number_input != 0)
        {
            Console.Write("Enter a number (pressing zero will quit): ");
            
            string Response = Console.ReadLine();
            number_input = int.Parse(Response);
            
            if (number_input != 0)
            {
                numbers.Add(number_input);
            }
        }

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");
   
        int max = numbers[0];
        int min = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
            if (number < min)
            {
                min = number;
            }
        }

        Console.WriteLine($"The largest number is: {max}");
        Console.WriteLine($"The smallest number is: {min}");

    }
}