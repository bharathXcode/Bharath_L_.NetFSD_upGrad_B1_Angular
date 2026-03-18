using System;
using System.Collections.Generic;
using System.Text;

// Interface
interface ISales
{
    int YearlySales();
}

// Abstract Class
abstract class SalesBase
{
    public int DailySales()
    {
        return 400;
    }

    public abstract int MonthlySales();
}

// ------------------- MAIN CLASS -------------------
class SalesCalculator : SalesBase, ISales
{
    public override int MonthlySales()
    {
        return DailySales() * 30;
    }

    public int YearlySales()
    {
        return MonthlySales() * 12;
    }
}

// ------------------- MAIN -------------------
class Q2_SalesAbstractInterfaceSystem
{
    static void Main()
    {
        SalesCalculator obj = new SalesCalculator();

        Console.WriteLine("Daily sales: Rs." + obj.DailySales());
        Console.WriteLine("Monthly sales: Rs." + obj.MonthlySales());
        Console.WriteLine("Annual sales: Rs." + obj.YearlySales());
    }
}
