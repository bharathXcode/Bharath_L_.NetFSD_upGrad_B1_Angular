using System;
using Microsoft.Data.SqlClient;

class Assignment1_Student
{
    string connStr =
    "Data Source=DESKTOP-VDQELDT\\SQLEXPRESS;Initial Catalog=AdoDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

    // ADD
    public void AddStudent(string name, int age, string grade)
    {
        using var con = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand(
            "INSERT INTO Students(Name,Age,Grade) VALUES(@n,@a,@g)", con);

        cmd.Parameters.Add("@n", System.Data.SqlDbType.NVarChar).Value = name;
        cmd.Parameters.Add("@a", System.Data.SqlDbType.Int).Value = age;
        cmd.Parameters.Add("@g", System.Data.SqlDbType.NVarChar).Value = grade;

        con.Open();
        cmd.ExecuteNonQuery();

        Console.WriteLine("Student Added...");
    }

    // READ
    public void GetAllStudents()
    {
        using var con = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand("SELECT * FROM Students", con);

        con.Open();
        SqlDataReader r = cmd.ExecuteReader();

        bool hasData = false;

        while (r.Read())
        {
            hasData = true;
            Console.WriteLine($"{r["Id"]} {r["Name"]} {r["Age"]} {r["Grade"]}");
        }

        if (!hasData)
            Console.WriteLine("No records found...");
    }

    // UPDATE
    public void UpdateStudent(int id, string grade)
    {
        using var con = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand(
            "UPDATE Students SET Grade=@g WHERE Id=@id", con);

        cmd.Parameters.Add("@g", System.Data.SqlDbType.NVarChar).Value = grade;
        cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

        con.Open();
        int rows = cmd.ExecuteNonQuery();

        Console.WriteLine(rows > 0 ? "Updated..." : "ID not found...");
    }

    // DELETE
    public void DeleteStudent(int id)
    {
        using var con = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand(
            "DELETE FROM Students WHERE Id=@id", con);

        cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

        con.Open();
        int rows = cmd.ExecuteNonQuery();

        Console.WriteLine(rows > 0 ? "Deleted..." : "ID not found...");
    }

    // MAIN METHOD (INSIDE SAME CLASS)
    static void Main()
    {
        Assignment1_Student s = new Assignment1_Student();

        while (true)
        {
            Console.WriteLine("\n--- Student Management ---");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View Students");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");

            int ch = int.Parse(Console.ReadLine());

            switch (ch)
            {
                case 1:
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Age: ");
                    int age = int.Parse(Console.ReadLine());

                    Console.Write("Enter Grade: ");
                    string grade = Console.ReadLine();

                    s.AddStudent(name, age, grade);
                    break;

                case 2:
                    s.GetAllStudents();
                    break;

                case 3:
                    Console.Write("Enter Id: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write("Enter New Grade: ");
                    string g = Console.ReadLine();

                    s.UpdateStudent(id, g);
                    break;

                case 4:
                    Console.Write("Enter Id: ");
                    int did = int.Parse(Console.ReadLine());

                    s.DeleteStudent(did);
                    break;

                case 5:
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}