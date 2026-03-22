using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnMethods
{
    internal class Compute
    {
        //method overloading
        public void Sum(int a,int b)
        {
            Console.WriteLine(a + b);
        }
        public void Sum(int a,int b,int c)
        {
            Console.WriteLine(a + b + c);
        }
        public void Sum(double a,double b)
        {
            Console.WriteLine(a + b);
        }
        static void Main()
        {
            Compute obj=new Compute();
            obj.Sum(12, 3);
            obj.Sum(12.2, 23.3);
            obj.Sum(2, 3, 4);
        }
    }
}
