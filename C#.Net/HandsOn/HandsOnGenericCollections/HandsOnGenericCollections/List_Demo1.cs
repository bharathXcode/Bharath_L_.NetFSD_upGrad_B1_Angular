using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnGenericCollections
{
    internal class List_Demo1
    {
        static void Main()
        {
            List<Student> studentsList = new List<Student> //collection initializer
        {
            new Student { Id = 1, Name = "Alice", 
                Marks = 85 },
            new Student { Id = 2, Name = "Bob", 
                Marks = 90 }
        };

            studentsList.Add(new Student { Id = 3, Name = "Charlie", Marks = 70 });
            studentsList.Insert(1, new Student { Id = 4, Name = "David", Marks = 88 });

            Student s = studentsList[2];
            Console.WriteLine(s); //invoke ToString() by default
            Console.WriteLine("All Students:");
            foreach(var  student in studentsList)
            {
                Console.WriteLine(student);
            }
            

            
        }
    }
}
