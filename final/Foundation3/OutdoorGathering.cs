public class OutdoorGathering : Event
{
    private string weatherForecast; // weather forecast
    public OutdoorGathering(string title, string description, string date, string time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        this.weatherForecast = weatherForecast; // set weather forecast
    }
    public override string GetFullDetails()
    {
        // return full details
        return $"{GetStandardDetails()}\nType: Outdoor Gathering\nWeather Forecast: {weatherForecast}";
    }
    public override string GetShortDescription()
    {
        return $"Outdoor Gathering - {Title} on {Date}"; // return short description
    }
}