using System;
using System.Collections.Generic;
using System.Text;

class Furniture
{
    public int OrderId;
    public string OrderDate;
    public int Qty;
    public string PaymentMode;

    public virtual void GetData()
    {
        Console.Write("OrderId: ");
        OrderId = int.Parse(Console.ReadLine());

        Console.Write("OrderDate: ");
        OrderDate = Console.ReadLine();

        Console.Write("Qty: ");
        Qty = int.Parse(Console.ReadLine());

        Console.Write("PaymentMode: ");
        PaymentMode = Console.ReadLine();
    }

    public virtual void ShowData()
    {
        Console.WriteLine($"{OrderId} {OrderDate} {Qty} {PaymentMode}");
    }
}

class Chair : Furniture
{
    public string ChairType;
    public string Purpose;
    public double Rate;

    public override void GetData()
    {
        base.GetData();

        Console.Write("Chair Type: ");
        ChairType = Console.ReadLine();

        Console.Write("Purpose: ");
        Purpose = Console.ReadLine();

        Console.Write("Rate: ");
        Rate = double.Parse(Console.ReadLine());
    }

    public override void ShowData()
    {
        base.ShowData();
        Console.WriteLine($"{ChairType} {Purpose} {Rate}");
    }
}

class Cot : Furniture
{
    public string CotType;
    public string Capacity;
    public double Rate;

    public override void GetData()
    {
        base.GetData();

        Console.Write("Cot Type: ");
        CotType = Console.ReadLine();

        Console.Write("Capacity: ");
        Capacity = Console.ReadLine();

        Console.Write("Rate: ");
        Rate = double.Parse(Console.ReadLine());
    }

    public override void ShowData()
    {
        base.ShowData();
        Console.WriteLine($"{CotType} {Capacity} {Rate}");
    }
}

class Q6_FurnitureManagement
{
    static void Main()
    {
        Furniture f;

        Console.WriteLine("1. Chair  2. Cot");
        int choice = int.Parse(Console.ReadLine());

        if (choice == 1)
            f = new Chair();
        else
            f = new Cot();

        f.GetData();
        f.ShowData();
    }
}
