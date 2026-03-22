using System;
namespace MyFirstConsoleApp
{
     class Program
    {
        //class variable
        public int age;
        public string name;
        static void Main(string[] args)
        {
            int[] no = new int[] { 1, 2, 3 };
            Console.WriteLine("Hello, World!");
            Product obj=new Product();
            obj.Details();
            //variable declaration
            int a;//local variable
            //assign value to varaible
            a = 10;
            Console.WriteLine("a= " + a);
        }
    }
}
