using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnCsharpNewFeatures
{
    //primary constructors for classes
    public class Customer(string name, int age)
    {
        public string Name => name;
        public int Age => age;
        public void PrintInfo() => Console.WriteLine($"Name:{name} Age:{age}");
    }
    internal class Demo1
    {
        static void Main()
        {
            var customer = new Customer("Virat", 36);
            Console.WriteLine(customer.Name);
            Console.WriteLine(customer.Age);
            customer.PrintInfo();

        }
    }
}
