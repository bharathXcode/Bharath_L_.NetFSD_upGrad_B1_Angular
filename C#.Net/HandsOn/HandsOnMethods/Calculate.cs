using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnMethods
{
    internal class Calculate
    {
        public int Add(int a,int b)
        {
            int result = 0; //local variable
            result = a + b;
            return result;
        }
        public static double Sqaure(double a)
        {
            return a * a;
        }
        public static bool IsEven(int a)
        {
            return a % 2 == 0 ? true : false;
        }
        public string[] GetFlowers()
        {
            return new string[4] { "Rose", "Lilly", "Jasmine", "Tulips" };
        }
        static void Main()
        {
            Calculate calc = new Calculate();
            int r=calc.Add(10,20);
            Console.WriteLine(Calculate.Sqaure(12));
            Console.WriteLine(Calculate.IsEven(12)?"Even":"Odd");
            foreach(string s in calc.GetFlowers())
            {
                Console.WriteLine(s);
            }
        }
    }
}
