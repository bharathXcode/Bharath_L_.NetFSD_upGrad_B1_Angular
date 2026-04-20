using System;
using System.Collections.Generic;
using System.Linq;

// Q4 - Employee management using LINQ
class Q4_L2_EmployeeManagement
{
    class Employee
    {
        public int Id;
        public string Name;
        public string Department;
        public double Salary;
    }

    static void Main(string[] args)
    {
        // Sample employee data
        var emp = new List<Employee>
        {
            new Employee{Id=1, Name="A", Department="IT", Salary=5000},
            new Employee{Id=2, Name="B", Department="HR", Salary=4000},
            new Employee{Id=3, Name="C", Department="IT", Salary=7000}
        };

        // Filter IT employees
        var itDept = emp.Where(e => e.Department == "IT");

        // Get employee with highest salary
        var highest = emp.OrderByDescending(e => e.Salary).First();

        // Calculate average salary
        var avg = emp.Average(e => e.Salary);

        // Group employees by department
        var group = emp.GroupBy(e => e.Department);

        // Count employees per department
        var count = emp.GroupBy(e => e.Department)
                       .Select(g => new { Dept = g.Key, Count = g.Count() });
    }
}
