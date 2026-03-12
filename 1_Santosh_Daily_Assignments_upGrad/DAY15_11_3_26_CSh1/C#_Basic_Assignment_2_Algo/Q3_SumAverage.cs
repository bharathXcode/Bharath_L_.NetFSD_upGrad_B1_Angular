using System;

class Q3_SumAverage
{
    public static void Run()
    {
        double sum = 0;

        Console.WriteLine("Enter 5 numbers:");

        for (int i = 1; i <= 5; i++)
        {
            double num = Convert.ToDouble(Console.ReadLine());
            sum += num;
        }

        double average = sum / 5;

        Console.WriteLine("Sum = " + sum);
        Console.WriteLine("Average = " + average);
    }
}
