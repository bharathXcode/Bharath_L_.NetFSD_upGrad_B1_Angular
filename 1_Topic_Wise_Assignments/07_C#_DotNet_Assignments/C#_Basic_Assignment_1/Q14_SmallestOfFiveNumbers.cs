using System;

class Q14_SmallestOfFiveNumbers
{
    public static void Run()
    {
        int min = int.MaxValue;

        Console.WriteLine("Enter 5 numbers:");

        for (int i = 0; i < 5; i++)
        {
            int num = Convert.ToInt32(Console.ReadLine());

            if (num < min)
                min = num;
        }

        Console.WriteLine("Smallest = " + min);
    }
}
