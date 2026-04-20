using System;

class Q5_CountOddEvenNumbers
{
    public static void Run()
    {
        int even = 0, odd = 0;

        Console.WriteLine("Enter 5 numbers:");

        for (int i = 0; i < 5; i++)
        {
            int num = Convert.ToInt32(Console.ReadLine());

            if (num % 2 == 0)
                even++;
            else
                odd++;
        }

        Console.WriteLine("Even count = " + even);
        Console.WriteLine("Odd count = " + odd);
    }
}