using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public int Id;
    public string Name;
    public int Marks;
}

class Q2_DictionaryStudent
{
    public static void Main()
    {
        Dictionary<int, Student> students = new Dictionary<int, Student>
        {
            {1, new Student{Id=1, Name="A", Marks=80}},
            {2, new Student{Id=2, Name="B", Marks=60}},
            {3, new Student{Id=3, Name="C", Marks=90}},
            {4, new Student{Id=4, Name="D", Marks=70}},
            {5, new Student{Id=5, Name="E", Marks=85}}
        };

        Console.WriteLine("Student 1: " + students[1].Name);
        Console.WriteLine("Exists ID 2: " + students.ContainsKey(2));

        students[2].Marks = 75;
        students.Remove(3);

        Console.WriteLine("\nMarks > 75:");
        foreach (var s in students.Values.Where(x => x.Marks > 75))
            Console.WriteLine(s.Name);
    }
}


