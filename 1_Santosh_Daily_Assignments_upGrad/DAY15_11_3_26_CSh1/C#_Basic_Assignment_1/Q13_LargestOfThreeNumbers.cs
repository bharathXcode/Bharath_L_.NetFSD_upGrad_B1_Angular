using System;

class Q13_LargestOfThreeNumbers
{
    public static void Run()
    {
        Console.Write("Enter first number: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        int b = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter third number: ");
        int c = Convert.ToInt32(Console.ReadLine());

        int largest = Math.Max(a, Math.Max(b, c));

        Console.WriteLine("Largest = " + largest);
    }
}
