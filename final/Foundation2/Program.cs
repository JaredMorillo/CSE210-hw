using System;

class Program
{
    static void Main(string[] args)
    {
        // Create products
        Product product1 = new Product("D&D Boardgame", 1, 10.0m, 2);
        Product product2 = new Product("Amazon Alexa", 2, 5.0m, 3);

        // Create addresses
        Address address1 = new Address("123 Street", "Cityville", "State 1", "USA");
        Address address2 = new Address("456 Road", "Townsville", "State 2", "Canada");

        // Create customers
        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Jane Smith", address2);

        // Create orders
        Order order1 = new Order(new List<Product> { product1, product2 }, customer1);
        Order order2 = new Order(new List<Product> { product2 }, customer2);

        // Get packing label, shipping label, and total cost for order 1
        Console.WriteLine("Order 1");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Total Cost: $" + order1.CalculateTotalCost());

        Console.WriteLine("--------------------------------------");

        // Get packing label, shipping label, and total cost for order 2
        Console.WriteLine("Order 2");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("Total Cost: $" + order2.CalculateTotalCost());
    }
}
public class Product
{
    public string Name { get; private set; }
    public int ProductId { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }

    public Product(string name, int productId, decimal price, int quantity)
    {
        Name = name;
        ProductId = productId;
        Price = price;
        Quantity = quantity;
    }

    public decimal CalculatePrice()
    {
        return Price * Quantity;
    }
}

public class Address
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string StateProvince { get; private set; }
    public string Country { get; private set; }

    public Address(string street, string city, string stateProvince, string country)
    {
        Street = street;
        City = city;
        StateProvince = stateProvince;
        Country = country;
    }

    public bool IsUSA()
    {
        return string.Equals(Country, "USA", StringComparison.OrdinalIgnoreCase);
    }

    public string GetFullAddress()
    {
        return $"{Street}\n{City}, {StateProvince}\n{Country}";
    }
}

public class Customer
{
    public string Name { get; private set; }
    public Address Address { get; private set; }

    public Customer(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    public bool IsUSACustomer()
    {
        return Address.IsUSA();
    }
}

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
