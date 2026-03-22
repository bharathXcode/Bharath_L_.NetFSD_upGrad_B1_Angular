using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace HandsOnArrays
{
    internal class Demo2
    {
        static void Main()
        {
            string[] employees = new string[5] { "Raj", "Kavya", "Rohith", "Pavan", "Vikas" };
            Console.WriteLine("Size: " + employees.Length);
            Console.WriteLine("Dimension: " + employees.Rank);
            string[] copy = new string[3];
            Array.Copy(employees, copy, 3);
            foreach(string e in copy)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine();
            //sort array elements
            Array.Sort(employees);
            Array.Reverse(employees);

            foreach (string employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
