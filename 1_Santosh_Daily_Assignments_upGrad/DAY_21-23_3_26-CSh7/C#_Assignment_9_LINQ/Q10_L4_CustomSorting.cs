using System;
using System.Collections.Generic;
using System.Linq;

// Q10 - Custom sorting
class Q10_L4_CustomSorting
{
    class Employee
    {
        public string Department;
        public double Salary;
    }

    static void Main(string[] args)
    {
        // Sample data
        var emp = new List<Employee>
        {
            new Employee{Department="IT", Salary=5000},
            new Employee{Department="HR", Salary=6000},
            new Employee{Department="IT", Salary=7000}
        };

        // Sort by Department ASC, then Salary DESC
        var sorted = emp.OrderBy(e => e.Department)
                        .ThenByDescending(e => e.Salary);

        // Output
        sorted.ToList().ForEach(e => Console.WriteLine($"{e.Department} - {e.Salary}"));
    }
}
