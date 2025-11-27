using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment simpleAssignment = new Assignment("John Doe", "History");
        Console.WriteLine(simpleAssignment.GetSummary());
        Console.WriteLine();

        MathAssignment mathAssignment = new MathAssignment("Jane Smith", "Algebra", "5.1", "1-10");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());
        Console.WriteLine();

        WritingAssignment writingAssignment = new WritingAssignment("Emily Johnson", "Literature", "The Great Gatsby Analysis");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}