using System;

class Q7_JourneyTime
{
    public static void Run()
    {
        Console.Write("Enter distance: ");
        double distance = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter speed: ");
        double speed = Convert.ToDouble(Console.ReadLine());

        double time = distance / speed;

        Console.WriteLine("Time taken = " + time);
    }
}
