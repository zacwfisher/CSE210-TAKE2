using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomeGenerator = new Random();
        int magicNumber = randomeGenerator.Next(1, 101);

        int userGuess = -1;

        while (userGuess != magicNumber)
        {
            Console.WriteLine("Guess a number between 1 and 100:");
            string userInput = Console.ReadLine();
            userGuess = int.Parse(userInput);

            if (userGuess < magicNumber)
            {
                Console.WriteLine("Too low! Try again.");
            }
            else if (userGuess > magicNumber)
            {
                Console.WriteLine("Too high! Try again.");
            }
            else
            {
                Console.WriteLine("Congratulations! You've guessed the magic number!");
            }
        }
    }
}