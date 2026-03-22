using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnProperties
{
    internal class Circle
    {
        private double r;
        private const double PI = 3.14;
        public Circle(double r)
        {
            this.r = r;
        }
        //Property
        public double Area //Read Only Property
        {
            get { return PI * r * r; }
        }
        public double Radius
        {
            get { return r; }
            private set;
        }
        static void Main()
        {
            Circle c = new Circle(12.3);
            Console.WriteLine($"Area of Circle with Radius {c.Radius} is {c.Area}");
        }
    }
}
