using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnClassVariables_Instance
{
    class Student
    {
        //instance variables(Default)
        public int id;
        public string name;
    }
    class Program
    {
        static void Main()
        {
            Student s1 = new Student();
            Student s2 = new Student();
            s1.id = 1;
            s1.name = "Rahul";
            s2.id = 2;
            s2.name = "Amit";
            Console.WriteLine(s1.name);
            Console.WriteLine(s2.name);
        }
    }
}
