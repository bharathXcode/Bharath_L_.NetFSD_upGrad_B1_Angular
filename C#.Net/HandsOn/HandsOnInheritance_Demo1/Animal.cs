using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnInheritance
{
    internal class Animal
    {
        public string Name { get; set; }
        public void Eat()
        {
            Console.WriteLine("Animal Eats..");
        }
    }
    class Dog:Animal
    {
        //All public members of Animal can use directly in Dog class
        //aditional functions
        public void Bark()
        {
            Console.WriteLine("Hello My Name: " + Name);
            Console.WriteLine($" {Name} Barks...");
        }
    }
    class Test_Dog
    {
        static void Main()
        {
            Dog d = new Dog(); //instantiate child class object
            //access all parent class public members using child class reference
            d.Name = "Puppy";
            d.Eat(); //parent member
            d.Bark(); //child members
            Animal a = new Animal(); //can access only Animal functions
            a.Eat();
            Animal animal = new Dog(); //object of parent class and instance of child class
            //using animal object can access all public members of Animal class and
            //override members of child class
            animal.Eat();
           
        }
    }
}
