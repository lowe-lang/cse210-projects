using System;

class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address address1 = new Address("123 Main St", "Provo", "UT", "USA");
        Address address2 = new Address("456 Market Ave", "Toronto", "ON", "Canada");

        // Create customers
        Customer customer1 = new Customer("John Smith", address1);
        Customer customer2 = new Customer("Mary Johnson", address2);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "P001", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "P002", 25.50, 2));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Phone", "P003", 699.99, 1));
        order2.AddProduct(new Product("Headphones", "P004", 120.00, 1));
        order2.AddProduct(new Product("Charger", "P005", 20.00, 3));

        // Display order1
        Console.WriteLine("Order 1:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():0.00}");
        Console.WriteLine();

        // Display order2
        Console.WriteLine("Order 2:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():0.00}");
    }
}
