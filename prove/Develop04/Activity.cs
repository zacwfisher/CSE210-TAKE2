using System;

public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _logCount;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _logCount = 0;
    }

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Starting {_name}...");
        Console.WriteLine(_description);

        Console.Write("Enter duration in seconds: ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int duration) && duration > 0)
        {
            _duration = duration;
        }
        else
        {
            _duration = 60;
            Console.WriteLine("Invalid input. Defaulting duration to 60 seconds.");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        Console.WriteLine("Prepare to begin...");
        PauseWithSpinner(3);
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine($"You have completed the {_name} for {_duration} seconds.");
        _logCount++;
        Console.WriteLine("Press Enter to return to the main menu...");
        PauseWithSpinner(3);
        _logCount++;
    }

    public abstract void RunActivity();

    protected void PauseWithSpinner(int seconds)
    {
        char[] spinner = new char[] { '|', '/', '-', '\\' };
        DateTime startTimew = DateTime.Now;
        Console.Write("...");
        while ((DateTime.Now - startTimew).TotalSeconds < seconds)
        {
            for (int i = 0; i < spinner.Length; i++)
            {
                Console.Write(spinner[i]);
                System.Threading.Thread.Sleep(250);
                Console.Write("\b");
            }
        }
    }

    protected void PauseWithCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            System.Threading.Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Starting {_name}...");
        Console.WriteLine(_description);
        Console.Write("Enter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());

        RunActivity();

        Console.WriteLine($"You have completed the {_name} for {_duration} seconds.");
        Console.WriteLine("Press Enter to return to the main menu...");
        Console.ReadLine();
    }

    public virtual string GetLog()
    {
        return $"{_name} - Duration: {_duration} seconds";
    }
}