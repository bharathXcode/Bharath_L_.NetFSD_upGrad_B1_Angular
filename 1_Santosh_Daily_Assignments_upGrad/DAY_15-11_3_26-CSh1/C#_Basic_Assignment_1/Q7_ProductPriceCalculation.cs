using System;

class Q7_ProductPriceCalculation
{
    public static void Run()
    {
        Console.Write("Enter product number (1-3): ");
        int product = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter quantity sold: ");
        int qty = Convert.ToInt32(Console.ReadLine());

        double price = 0;

        switch (product)
        {
            case 1: price = 22.5; break;
            case 2: price = 44.50; break;
            case 3: price = 9.98; break;
            default:
                Console.WriteLine("Invalid product");
                return;
        }

        Console.WriteLine("Total Price = " + price * qty);
    }
}
