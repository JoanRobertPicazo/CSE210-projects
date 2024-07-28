public class Lecture : Event
{
    private string speaker; // lecture speaker
    private int capacity; // lecture capacity
    public Lecture(string title, string description, string date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker; // set speaker
        this.capacity = capacity; // set capacity
    }
    public override string GetFullDetails()
    {
        // return full details
        return $"{GetStandardDetails()}\nType: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}";
    }
    public override string GetShortDescription()
    {
        return $"Lecture - {Title} on {Date}"; // return short description
    }
}