public class Address
{
    private string street; // street address
    private string city;   // city name
    private string state;  // state name
    private string country; // country name
    public Address(string street, string city, string state, string country)
    {
        this.street = street; // set street
        this.city = city; // set city
        this.state = state; // set state
        this.country = country; // set country
    }
    public bool IsInUSA()
    {
        return country == "USA"; // check if in USA
    }
    public override string ToString()
    {
        return $"{street}, {city}, {state}, {country}"; // return full address
    }
}