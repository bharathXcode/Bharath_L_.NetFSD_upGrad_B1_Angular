using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnArrays
{
    internal class Demo
    {
        static void Main()
        {
            object[] mixed = { "Rose", 12, 12.34, true }; //store mixed value
            string[] flowers = { "Rose", "Lilly", "Jasmine" };
            for (int i = 0; i <flowers.Length; i++)
            {
                    Console.WriteLine(flowers[i]);
            }
        }
    }
}
