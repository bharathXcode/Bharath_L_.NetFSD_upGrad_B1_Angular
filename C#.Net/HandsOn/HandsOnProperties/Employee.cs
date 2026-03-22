using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnProperties
{
    internal class Employee
    {
        private int _id;
        private double _salary;
        private static string _designation;
        //Write only Properties
        public int Id
        {
            set {  _id = value; }
        }
        public double Salary
        {
            set { _salary = value; }
        }
        public static string Designation
        {
            set { _designation = value; }
        }
        public void Details()
        {
            Console.WriteLine($"Id:{_id} Salary:{_salary} Designation:{_designation}");
        }
        static void Main()
        {
            Employee employee = new Employee();
            employee.Id = 4383;
            employee.Salary = 60000;
            Employee.Designation = "Developer";
        }
 
    }
}
