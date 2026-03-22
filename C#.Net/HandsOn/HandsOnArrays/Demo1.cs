using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnArrays
{
    internal class Demo1
    {
        static void Main()
        {
            //search value
            string[] employees = new string[5] { "Raj", "Kavya", "Rohith", "Pavan", "Vikas" };
            int flag = 0;
            Console.WriteLine("Enter Employee Name");
            string name = Console.ReadLine();
            for (int i = 0; i < employees.Length; i++)
            {
                if (name == employees[i])
                {
                    flag = 1;
                    break;
                }
            }
            if (flag == 0)
            {
                Console.WriteLine("Employee does not exist!!");
            }
            else
                Console.WriteLine("Employee Exist!!!!");
        }
    }
}
