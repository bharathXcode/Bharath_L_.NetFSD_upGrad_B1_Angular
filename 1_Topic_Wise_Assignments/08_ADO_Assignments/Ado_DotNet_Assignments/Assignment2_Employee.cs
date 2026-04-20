using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Ado_Assignment.Assignment2
{
    class Assignment2_Employees
    {
        private SqlConnection? connection = null;

        string connectionString = "Data Source=DESKTOP-VDQELDT\\SQLEXPRESS;Initial Catalog=AdoDB;Integrated Security=True;Trust Server Certificate=True";

        private SqlCommand? command = null;

        // INSERT
        public void InsertEmployee(string name, decimal salary, string dept)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                using (command = new SqlCommand("dbo.InsertEmployee", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Salary", salary);
                    command.Parameters.AddWithValue("@Department", dept);

                    connection.Open();
                    command.ExecuteNonQuery();

                    Console.WriteLine("Employee Inserted Successfully");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while inserting: " + ex.Message);
            }
            finally
            {
                connection?.Close();
            }
        }

        // FETCH
        public void GetByDepartment(string dept)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                using (command = new SqlCommand("dbo.GetEmployeesByDepartment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Department", dept);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"Id:{reader["EmpId"]} Name:{reader["Name"]} Salary:{reader["Salary"]} Department:{reader["Department"]}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while fetching: " + ex.Message);
            }
            finally
            {
                connection?.Close();
            }
        }

        // UPDATE
        public void UpdateSalary(int id, decimal salary)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                using (command = new SqlCommand("dbo.UpdateSalary", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@EmpId", id);
                    command.Parameters.AddWithValue("@Salary", salary);

                    connection.Open();
                    int rows = command.ExecuteNonQuery();

                    if (rows > 0)
                        Console.WriteLine("Salary Updated Successfully");
                    else
                        Console.WriteLine("Employee Not Found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while updating: " + ex.Message);
            }
            finally
            {
                connection?.Close();
            }
        }

        // DELETE (Parameterized Query)
        public void DeleteEmployee(int id)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                using (command = new SqlCommand("DELETE FROM Employees WHERE EmpId=@id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    int rows = command.ExecuteNonQuery();

                    if (rows > 0)
                        Console.WriteLine("Employee Deleted Successfully");
                    else
                        Console.WriteLine("Employee Not Found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while deleting: " + ex.Message);
            }
            finally
            {
                connection?.Close();
            }
        }
    }

    class Test_Assignment2_Employees
    {
        static void Main()
        {
            Assignment2_Employees emp = new Assignment2_Employees();

            while (true)
            {
                Console.WriteLine("\nEmployee Management System");
                Console.WriteLine("1. Insert Employee");
                Console.WriteLine("2. Get Employees by Department");
                Console.WriteLine("3. Update Salary");
                Console.WriteLine("4. Delete Employee");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice: ");

                int ch = int.Parse(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        Console.WriteLine("Enter Name:");
                        string name = Console.ReadLine();

                        Console.WriteLine("Enter Salary:");
                        decimal salary = decimal.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Department:");
                        string dept = Console.ReadLine();

                        emp.InsertEmployee(name, salary, dept);
                        break;

                    case 2:
                        Console.WriteLine("Enter Department:");
                        string d = Console.ReadLine();
                        emp.GetByDepartment(d);
                        break;

                    case 3:
                        Console.WriteLine("Enter Employee Id:");
                        int id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter New Salary:");
                        decimal newSalary = decimal.Parse(Console.ReadLine());

                        emp.UpdateSalary(id, newSalary);
                        break;

                    case 4:
                        Console.WriteLine("Enter Employee Id:");
                        int delId = int.Parse(Console.ReadLine());
                        emp.DeleteEmployee(delId);
                        break;

                    case 5:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }
}