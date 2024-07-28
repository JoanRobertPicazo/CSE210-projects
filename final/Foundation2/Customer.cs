using System;
class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA(); // check USA
    }

    public string GetName()
    {
        return name; // customer name
    }

    public string GetAddress()
    {
        return address.GetFullAddress(); // customer address
    }
}
