using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnInterfaces
{
    public interface Ishape
    {
        double Area();
    }
    public class Circle:Ishape
    {
        public int Radius { get; set; }
        public Circle(int  radius)
        {
            Radius = radius;
        }
        public double Area()
        {
            return Math.PI*Radius*Radius;
        }
        public double PeriMeter()
        {
            return 2 * Radius;
        }
    }
    public struct Rectangle:Ishape
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public double Area()
        {
            return Length * Width;
        }
    }
    internal class Demo0
    {
        static void Main()
        {
            //access only interface members implemented by Circle
            Ishape circle = new Circle(12);
            Console.WriteLine("Area of Circle: "+circle.Area());
            Circle circle1 = new Circle(14);
            Console.WriteLine("Area of Circle: " + circle1.Area());
            Console.WriteLine("Perimeter of Cicle: " + circle1.PeriMeter());
            Rectangle rectangle = new Rectangle() { Length = 23, Width = 78 };
            Console.WriteLine("Area of Rectangle: " + rectangle.Area());
        }
    }
}
