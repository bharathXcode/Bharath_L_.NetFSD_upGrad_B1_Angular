using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace HandsOnConstructors
{
    internal class Rectangle
    {
        public int x;
        public int y;
        public Rectangle(int x, int y) //parameter construcor
        {
            this.x = x;
            this.y = y;
        }
        public Rectangle(Rectangle r) //copy constructor(copy one object values to another object)
        {
            this.x=r.x;
            this.y=r.y;
        }
        public void Details()
        {
            Console.WriteLine($"x={x} y={y}");
        }
        static void Main()
        {
            int k = 10;
            int j = k;
            Rectangle r = new Rectangle(12, 3);
            Rectangle r1 = r; //shallow copy(objects are sharing the values and address)
            r.Details();
            r1.Details();
            r.x = 20;
            r.Details();
            r1.Details();
            Console.WriteLine();
            Rectangle r2 = new Rectangle(34, 45);
            Rectangle r3 = new Rectangle(r2);//deep copy(objects are sharing only values not address)
            r2.Details();
            r3.Details();
            r2.x = 90;
            r2.Details();
            r3.Details();

        }
    }

}
