using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by guiding you through slow breathing exercises.")
    {
    }

    public override void RunActivity()
    {
        DisplayStartingMessage();

        DateTime startTime = DateTime.Now;
        bool isInhale = true;
        int breathTime = 4;

        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            if (isInhale)
            {
                Console.WriteLine("Breathe in...");
            }
            else
            {
                Console.WriteLine("Breathe out...");
            }

            PauseWithCountdown(breathTime);
            isInhale = !isInhale;
        }

            for (int i = breathTime; i > 0; i--)
            {
                string dots = new string('.', breathTime - i + 1);

                string displayString = $"{dots}{isInhale}";
                Console.Write($"\r{displayString}   ");

                Thread.Sleep(1000);
            }

            Console.WriteLine();
            isInhale = !isInhale;
 }
}