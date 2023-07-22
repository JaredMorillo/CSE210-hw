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