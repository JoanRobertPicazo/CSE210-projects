using System;
using System.Collections.Generic;
class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        // initialize fields
        this.customer = customer;
        this.products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product); // add product
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (var product in products)
        {
            total += product.GetTotalCost(); // add product cost
        }

        if (customer.IsInUSA())
        {
            total += 5; // USA shipping
        }
        else
        {
            total += 35; // international shipping
        }

        return total; // total cost
    }

    public string GetPackingLabel()
    {
        string packingLabel = "Packing List:\n";
        foreach (var product in products)
        {
            // add product to label
            packingLabel += $"{product.GetName()} ({product.GetProductId()})\n";
        }
        return packingLabel; // packing label
    }

    public string GetShippingLabel()
    {
        // shipping label
        return $"Shipping To:\n{customer.GetName()}\n{customer.GetAddress()}";
    }
}
