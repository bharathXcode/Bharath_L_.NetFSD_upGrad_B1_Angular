using System;

class Q10_FibonacciSeries
{
    public static void Run()
    {
        int a = 0, b = 1;

        Console.Write(a + " " + b + " ");

        while (true)
        {
            int c = a + b;

            if (c > 40)
                break;

            Console.Write(c + " ");

            a = b;
            b = c;
        }
    }
}
