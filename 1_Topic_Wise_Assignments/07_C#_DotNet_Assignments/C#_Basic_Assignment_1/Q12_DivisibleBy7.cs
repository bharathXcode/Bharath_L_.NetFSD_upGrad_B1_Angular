using System;

class Q12_DivisibleBy7
{
    public static void Run()
    {
        for (int i = 200; i <= 300; i++)
        {
            if (i % 7 == 0)
                Console.WriteLine(i);
        }
    }
}
