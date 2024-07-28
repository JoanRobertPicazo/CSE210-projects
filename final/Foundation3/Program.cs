using System;
class Program
{
    static void Main(string[] args)
    {
        // create address objects
        Address johnsAddress = new Address("1234 Continental St", "New York", "NY", "USA"); // ai helped with this line
        Address cassianAddress = new Address("5678 High Table Ave", "Rome", "Lazio", "Italy"); // ai helped with this line
        Address sofiaAddress = new Address("7890 Dog Way", "Casablanca", "Morocco", "Morocco"); // ai helped with this line

        // create event objects
        Event lecture = new Lecture("John Wick's Combat Lecture", "Learn advanced combat techniques.", "10/10/2024", "10:00 AM", johnsAddress, "John Wick", 50); // ai helped with this line
        Event reception = new Reception("John Wick's Wedding Reception", "Join us to celebrate John Wick's wedding.", "10/11/2024", "6:00 PM", cassianAddress, "rsvp@continental.com"); // ai helped with this line
        Event outdoorGathering = new OutdoorGathering("Outdoor Training Session", "Train with John Wick in an outdoor environment.", "10/12/2024", "8:00 AM", sofiaAddress, "Sunny"); // ai helped with this line

        // display marketing messages
        Console.WriteLine(lecture.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine(lecture.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine(reception.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine(reception.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine(outdoorGathering.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine(outdoorGathering.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine(outdoorGathering.GetShortDescription());
    }
}