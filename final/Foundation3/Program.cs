using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Lecture lecture1 = new Lecture("Intro to C#", "A deep dive into classes", "2024-11-01", "10:00", address1, "Dr. Smith", 100);

        Address address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");
        Reception reception = new Reception("Tech Gala", "An evening of technology and networking.", "2024-10-15", "19:00", address2, "rsvp@techgala.com");

        Address address3 = new Address("789 Oak St", "New York", "NY", "USA");
        OutdoorGathering outdoorGathering = new OutdoorGathering("Community Picnic", "A fun day out in the park.", "2024-08-20", "12:00", address3, "Sunny with a chance of fun!");

        Console.WriteLine("=== Lecture Details ===");
        Console.WriteLine(lecture1.GetLectureDetails());
        Console.WriteLine(lecture1.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine("=== Reception Details ===");
        Console.WriteLine(reception.GetReceptionDetails());
        Console.WriteLine(reception.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine("=== Outdoor Gathering Details ===");
        Console.WriteLine(outdoorGathering.GetOutdoorGatheringDetails());
        Console.WriteLine(outdoorGathering.GetShortDescription());
    }
}