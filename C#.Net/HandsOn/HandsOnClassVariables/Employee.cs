using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnClassVariables_Static
{
    class Employee
    {
        public int empId;
        public string name;
        public static string company;
        public const double bonus = 5000; //not modifiable
        public void Details()
        {
            Console.WriteLine
    ($"Id:{empId} Name:{name} Company={company} Bonous={bonus}");
        }
    }
    class Program
    {
        static void Main()
        {
            Employee.company = "TCS";
            Employee e1 = new Employee() { empId=234,
                name="Charan"};
            Employee e2 = new Employee() { empId=321,
                name="Mohan"};
            Console.WriteLine(Employee.company);
            Console.WriteLine(Employee.bonus); //access const data using classname
            e1.Details();
            e2.Details();
            Employee.company = "CTS";
            Employee e3 = new Employee() { empId = 322, 
                name = "Kavya" };
            e3.Details();

        }
    }

}
