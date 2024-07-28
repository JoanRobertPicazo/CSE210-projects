public class Reception : Event
{
    private string rsvpEmail; // RSVP email
    public Reception(string title, string description, string date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail; // set RSVP email
    }
    public override string GetFullDetails()
    {
        // return full details
        return $"{GetStandardDetails()}\nType: Reception\nRSVP Email: {rsvpEmail}";
    }
    public override string GetShortDescription()
    {
        return $"Reception - {Title} on {Date}"; // return short description
    }
}