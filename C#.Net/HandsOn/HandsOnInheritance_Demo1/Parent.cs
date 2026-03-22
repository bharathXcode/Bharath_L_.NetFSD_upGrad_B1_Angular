using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnInheritance
{
    public class Parent
    {
        public string name;
        public Parent()
        {
            Console.WriteLine("Parent Constructor..");
        }
    }
    public class Child : Parent
    {
        public string name;
        public Child()
        {
            Console.WriteLine("Child Constructor");
        }
        public void Show()
        {
            Console.WriteLine("My Name: " + name);
            //base keyword use to access parent members in child class
            Console.WriteLine("My Parent Name: " + base.name);
        }
    }
    public class Test_Child
    {
        static void Main()
        {
            Child child = new Child();
        }
    }
}
