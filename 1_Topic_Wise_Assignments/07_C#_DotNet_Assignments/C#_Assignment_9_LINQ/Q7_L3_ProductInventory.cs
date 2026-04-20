using System;
using System.Collections.Generic;
using System.Linq;

// Q7 - Product Inventory using LINQ
class Q7_L3_ProductInventory
{
    // Product model
    class Product
    {
        public int Id;
        public string Name;
        public string Category;
        public double Price;
        public int Stock;
    }

    static void Main(string[] args)
    {
        // Sample data
        var products = new List<Product>
        {
            new Product{Id=1, Name="Laptop", Category="Electronics", Price=80000, Stock=5},
            new Product{Id=2, Name="Phone", Category="Electronics", Price=50000, Stock=20},
            new Product{Id=3, Name="Shirt", Category="Clothing", Price=1500, Stock=0}
        };

        // 1. Products with stock < 10
        var lowStock = products.Where(p => p.Stock < 10);

        // 2. Top 3 expensive products
        var top3 = products.OrderByDescending(p => p.Price).Take(3);

        // 3. Group products by category
        var groupByCategory = products.GroupBy(p => p.Category);

        // 4. Total stock per category
        var totalStock = products.GroupBy(p => p.Category)
                                 .Select(g => new { Category = g.Key, Total = g.Sum(x => x.Stock) });

        // 5. Check if any product is out of stock
        bool isOutOfStock = products.Any(p => p.Stock == 0);

        // Output
        Console.WriteLine("Low Stock Products:");
        lowStock.ToList().ForEach(p => Console.WriteLine(p.Name));

        Console.WriteLine("\nTop Expensive Products:");
        top3.ToList().ForEach(p => Console.WriteLine(p.Name));

        Console.WriteLine("\nTotal Stock Per Category:");
        totalStock.ToList().ForEach(t => Console.WriteLine($"{t.Category}: {t.Total}"));

        Console.WriteLine("\nAny Out of Stock:");
        Console.WriteLine(isOutOfStock);
    }
}
