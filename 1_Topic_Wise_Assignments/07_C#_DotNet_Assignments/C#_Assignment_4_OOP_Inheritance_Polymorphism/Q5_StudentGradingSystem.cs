using System;
using System.Collections.Generic;
using System.Text;

class Student
{
    public int StudentId;
    public string Name;
    public int Marks;

    public virtual string CalculateGrade()
    {
        return Marks > 50 ? "Pass" : "Fail";
    }
}

class SchoolStudent : Student
{
    public override string CalculateGrade()
    {
        return Marks > 40 ? "Pass" : "Fail";
    }
}

class CollegeStudent : Student
{
    public override string CalculateGrade()
    {
        return Marks > 50 ? "Pass" : "Fail";
    }
}

class OnlineStudent : Student
{
    public override string CalculateGrade()
    {
        return Marks > 60 ? "Pass" : "Fail";
    }
}

class Q5_StudentGradingSystem
{
    static void Main()
    {
        Student[] students =
        {
            new SchoolStudent(){Marks=45},
            new CollegeStudent(){Marks=45},
            new OnlineStudent(){Marks=45}
        };

        foreach (var s in students)
        {
            Console.WriteLine(s.CalculateGrade());
        }
    }
}