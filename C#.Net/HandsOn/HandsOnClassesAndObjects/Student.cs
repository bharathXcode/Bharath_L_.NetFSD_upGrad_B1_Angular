using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnClassesAndObjects
{
    internal class Student
    {
        //define here variables,methods,constructors,properties,evetns,indexers,destructors
        public int id;
        public string name;
        //method
        public void Display()
        {
            Console.WriteLine($"Id:{id} " +
                $"Name:{name}");
        }
    }
}
