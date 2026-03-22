using System.Net.Cache;

namespace HandsOnTuples
{
    internal class Program
    {
        //3. Returning Multiple Values from a Method
        public static (int min,int max) FindMinMix(int[]numbers)
        {
            int min = numbers.Min();
            int max= numbers.Max();
            return (min,max);
        }
        public static (string name,int age) GetPerson()
        {
            return ("Rohith", 34);
        }
        //Swappign two numbers
        public static (int, int) Swap(int a, int b) => (b, a);
        //tuple as method parameter
        public static void PrintPerson((string name,int age) person)
        {
            Console.WriteLine(person.name + " " + person.age);
        }
        static void Main(string[] args)
        {
            //Tuple is a basic data structure it can hold multiple data type values
            //old way to use tuple
            Tuple<int, string> t = new Tuple<int, string>(1, "Hello");
            Console.WriteLine(t.Item1);  // Output: 1
            Console.WriteLine(t.Item2); //Hello
            //modern way to use tuple
            var person = ("John", 25); //1. Creating a Tuple(C# 7.0 and later)
            Console.WriteLine(person.Item1);
            Console.WriteLine(person.Item2);
            // 2.Named Elements for Better Readability
            var student = (Name: "Viart", Age: 25);
            Console.WriteLine(student.Name);
            Console.WriteLine(student.Age);
            //3.Explicity Type
            (string name, int age) person1 = ("Virat", 35);
            //acccessing tuple values
            Console.WriteLine(person1.name);
            Console.WriteLine(person1.age);
            //4.Deconstructing a Tuple (Deconstruct to variables)
            var (name, age) = ("Virat", 25);
            Console.WriteLine($"Name:{name} Age:{age}");
            var result = FindMinMix(new int[] { 12, 23, 34, 45 });
            Console.WriteLine($"Min: {result.min}, Max: {result.max}");
            var (min, max) = FindMinMix(new int[] { 12, 34, 45 });
            Console.WriteLine($"Min: {min}, Max: {max}");
            var (x, y) = Swap(10, 20);
            Console.WriteLine($"x = {x}, y = {y}");  // Output: x = 20, y = 10
            var person2 = GetPerson();
            Console.WriteLine(person2.name);
            PrintPerson(("Virat", 35));
            //Tuple with collections
            List<(string name, int age)> people = new List<(string name, int age)>
            {
                ("monica",12),
                ("hari",11)
            };
            foreach(var p in  people)
            {
                Console.WriteLine(p.name);
            }
           
        }
    }
}
