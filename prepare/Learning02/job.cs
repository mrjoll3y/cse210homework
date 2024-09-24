using System;


public class Job 
{
    public string _jobTitle;
    public string _company;
    public string _yearStart;
    public string _yearLast;


    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_yearStart}-{_yearLast}");
    }
}