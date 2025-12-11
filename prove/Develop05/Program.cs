using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        var goals = new List<Goal>();
        int totalScore = 0;

        while (true)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal(goals);
                    break;
                case "2":
                    ListGoals(goals);
                    break;
                case "3":
                    Save("goals.txt", totalScore, goals);
                    Console.WriteLine("Goals saved.");
                    break;
                case "4":
                    (totalScore, goals) = Load("goals.txt");
                    Console.WriteLine("Loaded.");
                    break;
                case "5":
                    totalScore += RecordEvent(goals);
                    Console.WriteLine($"Your total score is: {totalScore}");
                    break;
                case "6":
                    return;
                case "7":
                    Console.WriteLine("Exiting program.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void CreateGoal(List<Goal> goals)
    {
        Console.WriteLine("Select Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter your choice: ");
        string goalType = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter goal points: ");
        int points = int.Parse(Console.ReadLine());

        Goal goal = goalType switch
        {
            "1" => new SimpleGoal(name, description, points),
            "2" => new EternalGoal(name, description, points),
            "3" => CreateChecklistGoal(name, description, points),
            _ => throw new InvalidOperationException("Invalid goal type"),
        };

        if (goal != null)
        {
            goals.Add(goal);
            Console.WriteLine("Goal created successfully.");
        }
        else
        {
            Console.WriteLine("Failed to create goal.");
        }
    }

    static ChecklistGoal CreateChecklistGoal(string name, string description, int points)
    {
        Console.Write("Enter number of times to complete for bonus: ");
        int targetCount = int.Parse(Console.ReadLine());
        Console.Write("Enter bonus points: ");
        int bonusPoints = int.Parse(Console.ReadLine());

        return new ChecklistGoal(name, description, points, targetCount, bonusPoints);
    }

    static void ListGoals(List<Goal> goals)
    {
        Console.WriteLine("Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
        }
    }

    static int RecordEvent(List<Goal> goals)
    {
        ListGoals(goals);
        Console.Write("Select a goal to record an event for: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < goals.Count)
        {
            return goals[index].RecordEvent();
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
            return 0;
        }
    }

    static void Save(string filename, int totalScore, List<Goal> goals)
    {
        using (var writer = new StreamWriter(filename))
        {
            writer.WriteLine(totalScore);
            foreach (var goal in goals)
            {
                writer.WriteLine(goal.Serialize());
            }
        }
    }

    static (int, List<Goal>) Load(string filename)
    {
        var goals = new List<Goal>();
        int totalScore = 0;

        using (var reader = new StreamReader(filename))
        {
            totalScore = int.Parse(reader.ReadLine());
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var goal = GoalFactory.FromString(line);
                if (goal != null)
                {
                    goals.Add(goal);
                }
            }
        }

        return (totalScore, goals);
    }
}