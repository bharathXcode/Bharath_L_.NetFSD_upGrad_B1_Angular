using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Text;

namespace HandsOnConstructors
{
    internal class Circle
    {
        public double radius;
        public static double PI;
        public Circle(double radius)
        {
            this.radius = radius;
        }
        //static constructor
        //static constructor invoke only once
        //it invokes before instance constructor
        static Circle()
        {
            PI = 3.14;
            Console.WriteLine("PI value is Initialized");
        }

        public void Area()
        {
            Console.WriteLine($"Area of Circle with radius {radius} "+ PI * radius * radius);
            
        }
        static void Main()
        {
            Circle c1 = new Circle(12.3);
            Circle c2 = new Circle(34.4);
            c1.Area();
            c2.Area();
        }
    }
}
