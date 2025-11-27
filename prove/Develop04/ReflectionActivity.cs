using System;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you overcame a challenge.",
        "Recall a moment when you helped someone in need.",
        "Reflect on a personal achievement that you're proud of.",
        "Consider a time when you learned something new about yourself.",
        "Think about a moment when you made a positive impact on others."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "What did you learn from this experience?",
        "How can you apply this lesson in the future?",
        "What emotions did you feel during this experience?",
        "How did this experience change your perspective?"
    };

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience.")
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
        while (DateTime.Now < endTime)
        {
            string question = _questions[rand.Next(_questions.Count)];
            Console.WriteLine(question);
            PauseWithSpinner(10);
        }

        DisplayEndingMessage();
    }
}