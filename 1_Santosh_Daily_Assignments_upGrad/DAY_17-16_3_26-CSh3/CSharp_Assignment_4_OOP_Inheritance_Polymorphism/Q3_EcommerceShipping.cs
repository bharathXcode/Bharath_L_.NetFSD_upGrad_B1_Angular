using System;
using System.Collections.Generic;
using System.Text;

class Order
{
    public int OrderId;
    public double OrderAmount;

    public virtual double CalculateShippingCost()
    {
        return 50;
    }
}

class StandardOrder : Order
{
    public override double CalculateShippingCost() => 50;
}

class ExpressOrder : Order
{
    public override double CalculateShippingCost() => 100;
}

class InternationalOrder : Order
{
    public override double CalculateShippingCost() => 500;
}

class Q3_EcommerceShipping
{
    static void Main()
    {
        List<Order> orders = new List<Order>()
        {
            new StandardOrder(),
            new ExpressOrder(),
            new InternationalOrder()
        };

        foreach (var order in orders)
        {
            Console.WriteLine(order.CalculateShippingCost());
        }
    }
}
