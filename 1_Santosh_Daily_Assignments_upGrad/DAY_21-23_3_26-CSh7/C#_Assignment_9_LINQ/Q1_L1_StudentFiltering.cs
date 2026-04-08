using System;
using System.Collections.Generic;
using System.Linq;

// Q1 - Student Filtering using LINQ
class Q1_L1_StudentFiltering
{
    // Student class representing structure of student data
    class Student
    {
        public int Id;
        public string Name;
        public int Age;
        public int Marks;
    }

    static void Main(string[] args)
    {
        // Creating sample student list
        var students = new List<Student>
        {
            new Student{Id=1, Name="Amit", Age=20, Marks=80},
            new Student{Id=2, Name="Ravi", Age=17, Marks=60},
            new Student{Id=3, Name="Kiran", Age=22, Marks=90},
            new Student{Id=4, Name="Anil", Age=25, Marks=70}
        };

        // 1. Filter students having marks greater than 75
        var highMarks = students.Where(s => s.Marks > 75);

        // 2. Filter students whose age is between 18 and 25
        var ageFilter = students.Where(s => s.Age >= 18 && s.Age <= 25);

        // 3. Sort students by marks in descending order
        var sorted = students.OrderByDescending(s => s.Marks);

        // 4. Select only Name and Marks (Projection)
        var projection = students.Select(s => new { s.Name, s.Marks });

        // Display results
        Console.WriteLine("Students with Marks > 75:");
        foreach (var s in highMarks)
            Console.WriteLine(s.Name);

        Console.WriteLine("\nStudents Age 18-25:");
        foreach (var s in ageFilter)
            Console.WriteLine(s.Name);

        Console.WriteLine("\nSorted by Marks:");
        foreach (var s in sorted)
            Console.WriteLine($"{s.Name} {s.Marks}");

        Console.WriteLine("\nName & Marks:");
        foreach (var s in projection)
            Console.WriteLine($"{s.Name} {s.Marks}");
    }
}
