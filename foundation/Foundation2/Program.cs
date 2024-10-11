using System;

class Program
{
    static void Main(string[] args)
    {
       
        Product product1 = new Product("Laptop", "P123", 1200.00, 1);
        Product product2 = new Product("Headphones", "P456", 150.00, 2);
        Product product3 = new Product("Mouse", "P789", 50.00, 3);

        
        Address customerAddress = new Address("123 Main St", "Los Angeles", "CA", "USA");

        
        Customer customer = new Customer("John Doe", customerAddress);

        
        Order order = new Order(customer);
        order.AddProduct(product1);
        order.AddProduct(product2);
        order.AddProduct(product3);

        
        Console.WriteLine($"Total Order Cost: ${order.GetTotalCost()}");

        
        Console.WriteLine("\nPacking Label:");
        Console.WriteLine(order.GetPackingLabel());

        
        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(order.GetShippingLabel());
    }
}
