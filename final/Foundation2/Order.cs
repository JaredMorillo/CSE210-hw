public class Order
{
    public List<Product> Products { get; private set; }
    public Customer Customer { get; private set; }

    public Order(List<Product> products, Customer customer)
    {
        Products = products;
        Customer = customer;
    }

    public decimal CalculateTotalCost()
    {
        decimal totalCost = 0;
        foreach (Product product in Products)
        {
            totalCost += product.CalculatePrice();
        }

        decimal shippingCost = Customer.IsUSACustomer() ? 5 : 35;
        return totalCost + shippingCost;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "";
        foreach (Product product in Products)
        {
            packingLabel += $"Name: {product.Name}, ID: {product.ProductId}\n";
        }

        return packingLabel;
    }

    public string GetShippingLabel()
    {
        Customer customer = Customer;
        Address address = customer.Address;
        string shippingLabel = $"Name: {customer.Name}\nAddress:\n{address.GetFullAddress()}";
        return shippingLabel;
    }
}
