using System;
using System.Collections.Generic;
using System.Text;

interface GovtRules
{
    double EmployeePF(double basicSalary);
    string LeaveDetails();
    double GratuityAmount(float serviceCompleted, double basicSalary);
}

// ------------------- TCS -------------------
class TCS : GovtRules
{
    public int EmpId { get; set; }
    public string Name { get; set; }
    public string Dept { get; set; }
    public string Desg { get; set; }
    public double BasicSalary { get; set; }

    public TCS(int id, string name, string dept, string desg, double salary)
    {
        EmpId = id;
        Name = name;
        Dept = dept;
        Desg = desg;
        BasicSalary = salary;
    }

    public double EmployeePF(double basicSalary)
    {
        double employeePF = 0.12 * basicSalary;
        double employerPF = 0.0833 * basicSalary;
        double pension = 0.0367 * basicSalary;

        return employeePF + employerPF + pension;
    }

    public string LeaveDetails()
    {
        return "1 Casual Leave/month\n12 Sick Leave/year\n10 Privilege Leave/year";
    }

    public double GratuityAmount(float serviceCompleted, double basicSalary)
    {
        if (serviceCompleted > 20)
            return 3 * basicSalary;
        else if (serviceCompleted > 10)
            return 2 * basicSalary;
        else if (serviceCompleted > 5)
            return 1 * basicSalary;
        else
            return 0;
    }
}

// ------------------- Accenture -------------------
class Accenture : GovtRules
{
    public int EmpId { get; set; }
    public string Name { get; set; }
    public string Dept { get; set; }
    public string Desg { get; set; }
    public double BasicSalary { get; set; }

    public Accenture(int id, string name, string dept, string desg, double salary)
    {
        EmpId = id;
        Name = name;
        Dept = dept;
        Desg = desg;
        BasicSalary = salary;
    }

    public double EmployeePF(double basicSalary)
    {
        double employeePF = 0.12 * basicSalary;
        double employerPF = 0.12 * basicSalary;
        return employeePF + employerPF;
    }

    public string LeaveDetails()
    {
        return "2 Casual Leave/month\n5 Sick Leave/year\n5 Privilege Leave/year";
    }

    public double GratuityAmount(float serviceCompleted, double basicSalary)
    {
        return 0; // Not applicable
    }
}

// ------------------- MAIN -------------------
class Q1_GovtRulesEmployeeSystem
{
    static void Main()
    {
        TCS tcs = new TCS(101, "Bharath", "IT", "Developer", 50000);
        Accenture acc = new Accenture(102, "Rahul", "HR", "Manager", 40000);

        Console.WriteLine("===== TCS EMPLOYEE DETAILS =====");
        Console.WriteLine("ID: " + tcs.EmpId);
        Console.WriteLine("Name: " + tcs.Name);
        Console.WriteLine("Department: " + tcs.Dept);
        Console.WriteLine("Designation: " + tcs.Desg);
        Console.WriteLine("Basic Salary: " + tcs.BasicSalary);

        Console.WriteLine("PF Contribution: " + tcs.EmployeePF(tcs.BasicSalary));
        Console.WriteLine("Leave Details:\n" + tcs.LeaveDetails());
        Console.WriteLine("Gratuity Amount: " + tcs.GratuityAmount(6, tcs.BasicSalary));

        Console.WriteLine("\n===============================\n");

        Console.WriteLine("===== ACCENTURE EMPLOYEE DETAILS =====");
        Console.WriteLine("ID: " + acc.EmpId);
        Console.WriteLine("Name: " + acc.Name);
        Console.WriteLine("Department: " + acc.Dept);
        Console.WriteLine("Designation: " + acc.Desg);
        Console.WriteLine("Basic Salary: " + acc.BasicSalary);

        Console.WriteLine("PF Contribution: " + acc.EmployeePF(acc.BasicSalary));
        Console.WriteLine("Leave Details:\n" + acc.LeaveDetails());
        Console.WriteLine("Gratuity Amount: " + acc.GratuityAmount(6, acc.BasicSalary));
    }
}