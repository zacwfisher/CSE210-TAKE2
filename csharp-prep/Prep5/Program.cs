using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();

        string userName = GetUserName();
        int userNumber = GetUserNumber();

        int squaredNumber = SquareNumber(userNumber);

        int birthYear;
        GetBirthYear(out birthYear);

        DisplayResult(userName, squaredNumber, birthYear);
    }

    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the C# Prep Program!");
    }

    static string GetUserName()
    {
        Console.WriteLine("Please enter your name:");
        return Console.ReadLine();
    }

    static int GetUserNumber()
    {
        Console.WriteLine("Please enter a number:");
        string userInput = Console.ReadLine();
        return int.Parse(userInput);
    }

    static void GetBirthYear(out int birthYear)
    {
        Console.WriteLine("Please enter your birth year:");
        string userInput = Console.ReadLine();
        birthYear = int.Parse(userInput);
    }

    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    static void DisplayResult(string name, int squaredNumber, int birthYear)
    {
        Console.WriteLine($"Hello, {name}!");
        Console.WriteLine($"The square of your number is: {squaredNumber}");
        Console.WriteLine($"You were born in the year: {birthYear}");
    }
}