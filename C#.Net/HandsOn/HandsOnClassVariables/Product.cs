using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnClassVariables_ReadOnly
{
    internal class Product
    {
        public readonly int Id;
        public string Name;
        public Product()
        {
            Id = 320232;
        }
    }
    class Program
    {
        static void Main()
        {
            Product p = new Product();
            p.Name="Test";
            //p.Id = 54098; //can not change read only at runtime
            Console.WriteLine(p.Id+" "+p.Name);
        }
    }
}
