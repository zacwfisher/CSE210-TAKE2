using System;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "List as many things as you can that you are grateful for.",
        "List the people who have positively influenced your life.",
        "List your personal strengths and qualities.",
        "List the places you have enjoyed visiting.",
        "List the activities that make you feel happy."
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public override void RunActivity()
    {
        DisplayStartingMessage();
        Random rand = new Random();

        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int itemCount = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(response))
            {
                itemCount++;
            }
        }

        Console.WriteLine($"You listed {itemCount} items!");
        DisplayEndingMessage();
    }
}