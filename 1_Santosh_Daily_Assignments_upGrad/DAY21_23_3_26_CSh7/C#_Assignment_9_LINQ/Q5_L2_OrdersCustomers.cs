using System;
using System.Collections.Generic;
using System.Linq;

// Q5 - Customers and Orders using Join
class Q5_L2_OrdersCustomers
{
    class Customer { public int Id; public string Name; }
    class Order { public int Id; public int CustomerId; public double Amount; }

    static void Main(string[] args)
    {
        // Sample data
        var customers = new List<Customer>
        {
            new Customer{Id=1, Name="A"},
            new Customer{Id=2, Name="B"}
        };

        var orders = new List<Order>
        {
            new Order{Id=1, CustomerId=1, Amount=3000},
            new Order{Id=2, CustomerId=1, Amount=2500}
        };

        // 1. Join customers with orders
        var join = customers.Join(orders, c => c.Id, o => o.CustomerId,
                                 (c, o) => new { c.Name, o.Amount });

        // 2. Total amount per customer
        var total = orders.GroupBy(o => o.CustomerId)
                          .Select(g => new { Id = g.Key, Sum = g.Sum(x => x.Amount) });

        // 3. Customers with total > 5000
        var high = total.Where(t => t.Sum > 5000);

        // 4. Customers with no orders
        var noOrders = customers.Where(c => !orders.Any(o => o.CustomerId == c.Id));
    }
}
