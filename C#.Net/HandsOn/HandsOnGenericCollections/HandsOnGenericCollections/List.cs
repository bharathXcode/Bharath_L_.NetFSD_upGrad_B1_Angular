using HandsOnGenericCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnGenericCollections_List
{
    /*
     List<T>

What it is: A dynamic array that can grow/shrink as needed.

When to use: When you need an ordered collection that allows duplicates and fast access by index.
     */
    class Program
    {
        static void Main()
        {
            //initiate List to strore string values
            List<string> students = new List<string>();
            List<int> numbers = new List<int>() { 12, 23, 34, 45, 4, 5 };//collection initializer
            //add items to List
            students.Add("Alice");
            students.Add("Bob");
            students.Add("Charlie");
            students.Insert(2, "John");

            // Access by index
            Console.WriteLine(students[1]); // Bob

            // Iterate
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
            //remove item
            //students.Remove("Bob");
            //students.RemoveAt(1); //pass index
            //students.Clear(); //removeall the items
            //sort items
            students.Sort();
           
        }
    }

}
