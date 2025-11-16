using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries;
    private List<string> _prompts;
    private Random _random;

    public Journal()
    {
        _entries = new List<Entry>();
        _random = new Random();
        _prompts = new List<string>
        {
            "What are you grateful for today?",
            "Describe a challenging moment you faced recently.",
            "What is a goal you have for the next month?",
            "Write about a memorable experience from your childhood.",
            "What is something new you learned today?"
        };
        _random = new Random();
    }

    private string GetRandomPrompt()
    {
        int index = _random.Next(0, _prompts.Count);
        return _prompts[index];
    }

    public void AddEntry()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        Console.Write("Your mood today: ");
        string mood = Console.ReadLine();

        Entry newEntry = new Entry(prompt, response, mood);
        _entries.Add(newEntry);
        Console.WriteLine("Journal entry added.");
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\n--- Displaying Journal Entries ---");
            foreach (Entry entry in _entries)
            {
                entry.Display();
            }
        }
    }

    public void SaveToFile()
    {
        Console.WriteLine("Enter the filename to save the journal:");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine($"{entry._date}|{entry._prompt}|{entry._response}");
                }
            }
            Console.WriteLine("Journal saved successfully.");
        }

        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while saving the journal: {e.Message}");
        }
    }

    public void LoadFile()
    {
        Console.WriteLine("Enter the filename to load the journal from:");
        string filename = Console.ReadLine();

        try
        {
            _entries.Clear();
            string[] lines = File.ReadAllLines(filename);

            char[] delimiter = new char[] { '|' };

            foreach (string line in lines)
            {
                string[] parts = line.Split(delimiter);
                if (parts.Length == 3)
                {
                    Entry entry = new Entry();
                    entry._date = parts[0];
                    entry._prompt = parts[1];
                    entry._response = parts[2];
                    entry._mood = parts[3];

                    _entries.Add(entry);
                }
            }
            Console.WriteLine("Journal loaded successfully.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The specified file was not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading the journal: {ex.Message}");
        }
    }
}