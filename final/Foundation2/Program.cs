using System;

class Program
{
    static void Main(string[] args)
    {
        // john wick's wedding
        Address address1 = new Address("1 Continental Hotel", "New York", "NY", "USA"); // event address
        Address address2 = new Address("2000 Stark Tower", "New York", "NY", "USA"); // event address
        Address address3 = new Address("10880 Malibu Point", "Malibu", "CA", "USA"); // event address

        // create events
        Lecture lecture = new Lecture("Wedding Preparations", "Pre-wedding lecture on security", "12/10/2023", "10:00 AM", address1, "Winston", 50);
        Reception reception = new Reception("Wedding Reception", "John Wick and his bride's reception", "01/05/2024", "8:00 PM", address2, "rsvp@continental.com");
        OutdoorGathering outdoorGathering = new OutdoorGathering("Honeymoon Send-off", "Outdoor gathering to send off the couple", "05/15/2024", "9:00 AM", address3, "Sunny");

        // display event details
        Console.WriteLine(lecture.GetStandardDetails()); // print standard details
        Console.WriteLine();
        Console.WriteLine(lecture.GetFullDetails()); // print full details
        Console.WriteLine();
        Console.WriteLine(lecture.GetShortDescription()); // print short description

        Console.WriteLine();

        Console.WriteLine(reception.GetStandardDetails()); // print standard details
        Console.WriteLine();
        Console.WriteLine(reception.GetFullDetails()); // print full details
        Console.WriteLine();
        Console.WriteLine(reception.GetShortDescription()); // print short description

        Console.WriteLine();

        Console.WriteLine(outdoorGathering.GetStandardDetails()); // print standard details
        Console.WriteLine();
        Console.WriteLine(outdoorGathering.GetFullDetails()); // print full details
        Console.WriteLine();
        Console.WriteLine(outdoorGathering.GetShortDescription()); // print short description
    }
}
