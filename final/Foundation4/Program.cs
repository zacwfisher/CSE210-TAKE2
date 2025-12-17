using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running("2024-06-01", 30, 5.0));
        activities.Add(new Cycling("2024-06-02", 45, 15.0));
        activities.Add(new Swimming("2024-06-03", 60, 20));

        Console.WriteLine("Activity Summary:");
        Console.WriteLine();

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }

        Console.WriteLine("End of Activity Summary.");
    }
}