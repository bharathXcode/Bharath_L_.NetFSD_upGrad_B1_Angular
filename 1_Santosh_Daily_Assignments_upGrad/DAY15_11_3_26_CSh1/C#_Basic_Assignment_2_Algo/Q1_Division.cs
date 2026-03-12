using System;

class Q1_Division
{
    public static void Run()
    {
        Console.Write("Enter first number: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter second number: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        double quotient = num1 / num2;

        Console.WriteLine("Quotient = " + quotient);
    }
}
