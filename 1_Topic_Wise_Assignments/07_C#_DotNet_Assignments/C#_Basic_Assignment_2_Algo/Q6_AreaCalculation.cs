using System;

class Q6_AreaCalculation
{
    public static void Run()
    {
        Console.Write("Enter length of rectangle: ");
        double length = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter width of rectangle: ");
        double width = Convert.ToDouble(Console.ReadLine());

        double rectArea = length * width;

        Console.Write("Enter side of square: ");
        double side = Convert.ToDouble(Console.ReadLine());

        double squareArea = side * side;

        Console.WriteLine("Area of Rectangle = " + rectArea);
        Console.WriteLine("Area of Square = " + squareArea);
    }
}
