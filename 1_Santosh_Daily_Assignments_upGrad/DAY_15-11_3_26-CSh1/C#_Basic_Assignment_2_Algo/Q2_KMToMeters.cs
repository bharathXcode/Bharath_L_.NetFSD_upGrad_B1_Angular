using System;

class Q2_KMToMeters
{
    public static void Run()
    {
        Console.Write("Enter distance in kilometers: ");
        double km = Convert.ToDouble(Console.ReadLine());

        double meters = km * 1000;

        Console.WriteLine("Distance in meters = " + meters);
    }
}
