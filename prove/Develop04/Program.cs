using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    public static List<Activity> Activities = new List<Activity>()
    {
        new BreathingActivity(),
        new ReflectionActivity(),
        new ListingActivity()
    };
    
    static void Main(string[] args)
    {
        string choice = "";
        while (choice != "4")
        {
            Console.Clear();
            DisplayMenu();

            Console.WriteLine("Select an activity (1-4): ");
            choice = Console.ReadLine();

            Activity selectedActivity = null;
            if (int.TryParse(choice, out int index) && index >= 1 && index <= 3)
            {
                selectedActivity = Activities[index - 1];
            }

            if (selectedActivity != null)
            {
                selectedActivity.Start();
            }
            else if (choice == "4")
            {
                Console.WriteLine("Exiting the program. Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }
    }

    public static void DisplayMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Quit");
    } 

    public static void DisplayLog()
    {
        Console.WriteLine("\n--- Activity Log ---");
        foreach (var activity in Activities)
        {
            Console.WriteLine(activity.GetLog());
        }
    }
}

