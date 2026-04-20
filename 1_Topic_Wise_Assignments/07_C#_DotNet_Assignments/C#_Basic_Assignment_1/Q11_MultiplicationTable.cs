using System;

class Q11_MultiplicationTable
{
    public static void Run()
    {
        Console.Write("Enter number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = 1; i <= 20; i++)
            Console.WriteLine(n + " x " + i + " = " + n * i);
    }
}