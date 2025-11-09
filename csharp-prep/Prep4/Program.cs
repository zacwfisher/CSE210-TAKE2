using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int Number = -1;
        while (Number != 0)
        {
            Console.WriteLine("Enter a number (or 0 to finish): ");
            string userInput = Console.ReadLine();
            Number = int.Parse(userInput);

            if (Number != 0)
            {
                numbers.Add(Number);
            }
        }

        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }

        Console.WriteLine($"The sum of the numbers you entered is: {sum}");

        float average = (float)sum / numbers.Count;
        Console.WriteLine($"The average of the numbers you entered is: {average}");

        int max = numbers[0];

        foreach (int num in numbers)
        {
            if (num > max)
            {
                max = num;
            }
        }

        Console.WriteLine($"The maximum number you entered is: {max}");
    }
}