using System;

public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;
    public string _mood;

    public Entry(string prompt, string response,string mood)
    {
        this._date = DateTime.Now.ToShortDateString();
        this._prompt = prompt;
        this._response = response;
        this._mood = mood;
    }

    public Entry()
    {
        this._date = "";
        this._prompt = "";
        this._response = "";
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} | Mood: {_mood}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine();
    }

    public string GetStringRepresentation()
    {
        return $"{_date}|{_prompt}|{_response}|{_mood}";
    }
}