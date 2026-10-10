using System.Collections.Generic;
using System.Text;

public class Order
{
    private readonly List<Product> _products;
    private readonly Customer _customer;

    public Order (Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal CalculateTotalCost()
    {
        decimal totalCost = 0;
        foreach (Product product in _products)
        {
            totalCost += product.GetTotalCost();
        }

        totalCost += _customer.LivesInUSA() ? 5m : 35m;

        return totalCost;
    }

    public string GetPackingLabel()
    {
        StringBuilder packingLabel = new StringBuilder();

        foreach (Product product in _products)
        {
            packingLabel.AppendLine(
                $"{product.GetName()} - {product.GetProductId()}");
        }

        return packingLabel.ToString();
    }

    public string GetShippingLabel()
    {
        return $"{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}