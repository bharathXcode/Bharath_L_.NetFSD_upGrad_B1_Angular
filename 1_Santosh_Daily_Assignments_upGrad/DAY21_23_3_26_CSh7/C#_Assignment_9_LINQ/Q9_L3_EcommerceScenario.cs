using System;
using System.Collections.Generic;
using System.Linq;

// Q9 - E-Commerce scenario
class Q9_L3_EcommerceScenario
{
    // Order model
    class Order
    {
        public string CustomerName;
        public DateTime OrderDate;
        public double TotalAmount;
    }

    static void Main(string[] args)
    {
        // Sample data
        var orders = new List<Order>
        {
            new Order{CustomerName="A", OrderDate=DateTime.Now.AddDays(-10), TotalAmount=1000},
            new Order{CustomerName="B", OrderDate=DateTime.Now.AddDays(-40), TotalAmount=2000},
            new Order{CustomerName="A", OrderDate=DateTime.Now, TotalAmount=3000}
        };

        // 1. Orders in last 30 days
        var recent = orders.Where(o => o.OrderDate >= DateTime.Now.AddDays(-30));

        // 2. Monthly sales
        var monthly = orders.GroupBy(o => new { o.OrderDate.Year, o.OrderDate.Month })
                            .Select(g => new { g.Key.Month, Total = g.Sum(x => x.TotalAmount) });

        // 3. Top 5 customers by spending
        var topCustomers = orders.GroupBy(o => o.CustomerName)
                                 .Select(g => new { Name = g.Key, Total = g.Sum(x => x.TotalAmount) })
                                 .OrderByDescending(x => x.Total)
                                 .Take(5);

        // 4. Highest order per month
        var highest = orders.GroupBy(o => o.OrderDate.Month)
                            .Select(g => g.OrderByDescending(x => x.TotalAmount).First());

        // Output
        Console.WriteLine("Recent Orders:");
        recent.ToList().ForEach(o => Console.WriteLine(o.CustomerName));

        Console.WriteLine("\nMonthly Sales:");
        monthly.ToList().ForEach(m => Console.WriteLine($"{m.Month}: {m.Total}"));

        Console.WriteLine("\nTop Customers:");
        topCustomers.ToList().ForEach(c => Console.WriteLine($"{c.Name}: {c.Total}"));

        Console.WriteLine("\nHighest Order Per Month:");
        highest.ToList().ForEach(o => Console.WriteLine(o.CustomerName));
    }
}
