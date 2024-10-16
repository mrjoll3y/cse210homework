using System;

class Program
{
        static void Main(string[] args)
    {
        Assignment a1 = new Assignment("Callen Jolley", "Division");
        Console.WriteLine(a1.GetSummary());
    

        MathAssignment a2 = new MathAssignment("Robert Fielding", "Fractions", "9.3", "2-12");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());
        
        WritingAssignment a3 = new WritingAssignment("Jocelyn Harker", "Egyprian Mummies", "The Process of Mummification");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}