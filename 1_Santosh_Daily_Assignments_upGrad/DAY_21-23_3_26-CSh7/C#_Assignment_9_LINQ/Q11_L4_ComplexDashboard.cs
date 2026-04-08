using System;
using System.Collections.Generic;
using System.Linq;

// Q11 - Complex dashboard analytics 
class Q11_L4_ComplexDashboard
{
    // Employee model
    class Employee
    {
        public string Department;
        public double Salary;
        public DateTime JoiningDate;
    }

    static void Main(string[] args)
    {
        // Sample employee data
        var emp = new List<Employee>
        {
            new Employee{Department="IT", Salary=5000, JoiningDate=DateTime.Now.AddMonths(-2)},
            new Employee{Department="HR", Salary=6000, JoiningDate=DateTime.Now.AddMonths(-8)},
            new Employee{Department="IT", Salary=8000, JoiningDate=DateTime.Now.AddMonths(-1)}
        };

        // 1. Total number of employees
        int totalEmployees = emp.Count();

        // 2. Department-wise average salary
        var avgSalary = emp.GroupBy(e => e.Department)
                           .Select(g => new
                           {
                               Department = g.Key,
                               AvgSalary = g.Average(x => x.Salary)
                           });

        // 3. Employees who joined in last 6 months
        var recentEmployees = emp.Where(e => e.JoiningDate >= DateTime.Now.AddMonths(-6));

        // 4. Highest paid employee in each department
        var highestPaid = emp.GroupBy(e => e.Department)
                             .Select(g => g.OrderByDescending(x => x.Salary).First());

        // 5. Salary distribution (min, max, avg)
        var salaryStats = new
        {
            MinSalary = emp.Min(e => e.Salary),
            MaxSalary = emp.Max(e => e.Salary),
            AvgSalary = emp.Average(e => e.Salary)
        };

        // Output
        Console.WriteLine($"Total Employees: {totalEmployees}");

        Console.WriteLine("\nAverage Salary by Department:");
        avgSalary.ToList().ForEach(a =>
            Console.WriteLine($"{a.Department}: {a.AvgSalary}"));

        Console.WriteLine("\nRecently Joined Employees:");
        recentEmployees.ToList().ForEach(e =>
            Console.WriteLine($"{e.Department} - {e.JoiningDate}"));

        Console.WriteLine("\nHighest Paid per Department:");
        highestPaid.ToList().ForEach(e =>
            Console.WriteLine($"{e.Department} - {e.Salary}"));

        Console.WriteLine($"\nSalary Stats -> Min: {salaryStats.MinSalary}, Max: {salaryStats.MaxSalary}, Avg: {salaryStats.AvgSalary}");
    }
}
