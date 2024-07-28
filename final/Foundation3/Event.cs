public abstract class Event
{
    public string Title { get; set; } // event title
    public string Description { get; set; } // event description
    public string Date { get; set; } // event date
    public string Time { get; set; } // event time
    public Address EventAddress { get; set; } // event address
    public Event(string title, string description, string date, string time, Address address)
    {
        Title = title; // set title
        Description = description; // set description
        Date = date; // set date
        Time = time; // set time
        EventAddress = address; // set address
    }
    public string GetStandardDetails()
    {
        // return standard details
        return $"{Title} - {Description}\nDate: {Date} Time: {Time}\nLocation: {EventAddress}";
    }
    public abstract string GetFullDetails();
    public abstract string GetShortDescription();
}