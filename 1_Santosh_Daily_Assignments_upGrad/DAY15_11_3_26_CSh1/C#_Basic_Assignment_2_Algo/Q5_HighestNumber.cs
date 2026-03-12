using System;

class Q5_HighestNumber
{
    public static void Run()
    {
        Console.Write("Enter first number: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        int b = Convert.ToInt32(Console.ReadLine());

        if (a > b)
            Console.WriteLine("Highest number = " + a);
        else
            Console.WriteLine("Highest number = " + b);
    }
}
