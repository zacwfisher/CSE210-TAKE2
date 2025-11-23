using System;

class Program
{
    private static Random _appRandom = new Random();

    static void Main(string[] args)
    {
        Reference reference1 = new Reference("John", 3, 16);
        Scripture scripture1 = new Scripture(reference1, "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        Reference reference2 = new Reference("Psalm", 23, 1);
        Scripture scripture2 = new Scripture(reference2, "The Lord is my shepherd; I shall not want.");

        Reference reference3 = new Reference("Proverbs", 3, 5);
        Scripture scripture3 = new Scripture(reference3, "Trust in the Lord with all your heart and lean not on your own understanding.");

        List<Scripture> scriptures = new List<Scripture> { scripture1, scripture2, scripture3 };

        Scripture currentScripture = scriptures[_appRandom.Next(scriptures.Count)];

        string userInput = "";

        while (userInput != "quit" && !currentScripture.IsCompletelyHidden)
        {
            Console.Clear();
            Console.WriteLine(currentScripture.DisplayScripture());
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            userInput = Console.ReadLine().ToLower();

            if (userInput != "quit")
            {
                currentScripture.HideWords(3);
            }
        }

        Console.Clear();
        Console.WriteLine(currentScripture.DisplayScripture());

        if (currentScripture.IsCompletelyHidden)
        {
            Console.WriteLine("\nAll words are hidden. Well done!");
        }
        else
        {
            Console.WriteLine("\nThank you for using the Scripture Memorizer.");
        }
    }
}