using System;

class Q3_NumbersBetweenTwoNumbers
{
    public static void Run()
    {
        Console.Write("Enter first number: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        int b = Convert.ToInt32(Console.ReadLine());

        for (int i = a + 1; i < b; i++)
            Console.WriteLine(i);
    }
}
