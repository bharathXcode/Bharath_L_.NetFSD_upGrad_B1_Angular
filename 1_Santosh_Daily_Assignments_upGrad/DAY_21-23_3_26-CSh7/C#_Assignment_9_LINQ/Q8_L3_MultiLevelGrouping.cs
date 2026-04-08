using System;
using System.Collections.Generic;
using System.Linq;

// Q8 - Multi-level grouping
class Q8_L3_MultiLevelGrouping
{
    // Student model
    class Student
    {
        public string Class;
        public string Subject;
        public int Marks;
    }

    static void Main(string[] args)
    {
        // Sample data
        var students = new List<Student>
        {
            new Student{Class="10", Subject="Math", Marks=80},
            new Student{Class="10", Subject="Science", Marks=70},
            new Student{Class="9", Subject="Math", Marks=60}
        };

        // Group by Class, then Subject
        var result = students.GroupBy(s => s.Class)
            .Select(c => new
            {
                Class = c.Key,
                Subjects = c.GroupBy(s => s.Subject)
                            .Select(sub => new
                            {
                                Subject = sub.Key,
                                AvgMarks = sub.Average(x => x.Marks)
                            })
            });

        // Output
        foreach (var cls in result)
        {
            Console.WriteLine($"Class: {cls.Class}");
            foreach (var sub in cls.Subjects)
                Console.WriteLine($"  {sub.Subject} Avg: {sub.AvgMarks}");
        }
    }
}
