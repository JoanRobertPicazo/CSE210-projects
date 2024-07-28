using System;
class Product
{
    private string name;
    private string productId;
    private double pricePerUnit;
    private int quantity;

    public Product(string name, string productId, double pricePerUnit, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.pricePerUnit = pricePerUnit;
        this.quantity = quantity;
    }

    public double GetTotalCost()
    {
        // calculate total cost
        return pricePerUnit * quantity;
    }

    public string GetName()
    {
        return name; // product name
    }

    public string GetProductId()
    {
        return productId; // product id
    }
}
