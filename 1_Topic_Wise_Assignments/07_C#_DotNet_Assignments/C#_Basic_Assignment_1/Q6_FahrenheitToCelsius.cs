using System;

class Q6_FahrenheitToCelsius
{
    public static void Run()
    {
        Console.Write("Enter temperature in Fahrenheit: ");
        double f = Convert.ToDouble(Console.ReadLine());

        double c = (f - 32) * 5 / 9;

        Console.WriteLine("Temperature in Celsius = " + c);
    }
}
