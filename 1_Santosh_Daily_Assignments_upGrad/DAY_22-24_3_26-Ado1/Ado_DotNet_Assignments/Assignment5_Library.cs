using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Ado_Assignment.Assignment5
{
    class Assignment5_Library
    {
        private SqlConnection connection = null;
        private SqlCommand command = null;

        // YOUR CONNECTION STRING
        string connectionString = "Data Source=DESKTOP-VDQELDT\\SQLEXPRESS;Initial Catalog=AdoDB;Integrated Security=True;Trust Server Certificate=True";

        // 1. Add Book
        public void AddBook(string title, string author, decimal price)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                using (command = new SqlCommand("INSERT INTO Books (Title, Author, Price) VALUES (@t, @a, @p)", connection))
                {
                    command.Parameters.AddWithValue("@t", title);
                    command.Parameters.AddWithValue("@a", author);
                    command.Parameters.AddWithValue("@p", price);

                    connection.Open();
                    command.ExecuteNonQuery();

                    Console.WriteLine("Book Added Successfully");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while adding book: " + ex.Message);
            }
        }

        // 2. View Books
        public void ViewBooks()
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                using (command = new SqlCommand("SELECT * FROM Books", connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine("Id:{0} Title:{1} Author:{2} Price:{3}",
                            reader["BookId"], reader["Title"], reader["Author"], reader["Price"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while fetching books: " + ex.Message);
            }
        }

        // 3. Update Book
        public void UpdateBook(int id, string title, string author, decimal price)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                using (command = new SqlCommand("UPDATE Books SET Title=@t, Author=@a, Price=@p WHERE BookId=@id", connection))
                {
                    command.Parameters.AddWithValue("@t", title);
                    command.Parameters.AddWithValue("@a", author);
                    command.Parameters.AddWithValue("@p", price);
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    int rows = command.ExecuteNonQuery();

                    if (rows > 0)
                        Console.WriteLine("Book Updated Successfully");
                    else
                        Console.WriteLine("Book Not Found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while updating: " + ex.Message);
            }
        }

        // 4. Delete Book
        public void DeleteBook(int id)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                using (command = new SqlCommand("DELETE FROM Books WHERE BookId=@id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    int rows = command.ExecuteNonQuery();

                    if (rows > 0)
                        Console.WriteLine("Book Deleted Successfully");
                    else
                        Console.WriteLine("Book Not Found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while deleting: " + ex.Message);
            }
        }

        // 5. Search Book by Name
        public void SearchBook(string name)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                using (command = new SqlCommand("SELECT * FROM Books WHERE Title LIKE @name", connection))
                {
                    command.Parameters.AddWithValue("@name", "%" + name + "%");

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    bool found = false;

                    while (reader.Read())
                    {
                        Console.WriteLine("Id:{0} Title:{1} Author:{2} Price:{3}",
                            reader["BookId"], reader["Title"], reader["Author"], reader["Price"]);
                        found = true;
                    }

                    if (!found)
                        Console.WriteLine("No matching books found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while searching: " + ex.Message);
            }
        }
    }

    class Test_Assignment5_Library
    {
        static void Main()
        {
            Assignment5_Library lib = new Assignment5_Library();

            while (true)
            {
                Console.WriteLine("\nLibrary Management System");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. View Books");
                Console.WriteLine("3. Update Book");
                Console.WriteLine("4. Delete Book");
                Console.WriteLine("5. Search Book");
                Console.WriteLine("6. Exit");
                Console.Write("Enter choice: ");

                int ch = int.Parse(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        Console.WriteLine("Enter Title:");
                        string title = Console.ReadLine();

                        Console.WriteLine("Enter Author:");
                        string author = Console.ReadLine();

                        Console.WriteLine("Enter Price:");
                        decimal price = decimal.Parse(Console.ReadLine());

                        lib.AddBook(title, author, price);
                        break;

                    case 2:
                        lib.ViewBooks();
                        break;

                    case 3:
                        Console.WriteLine("Enter Book Id:");
                        int id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter New Title:");
                        string newTitle = Console.ReadLine();

                        Console.WriteLine("Enter Author:");
                        string newAuthor = Console.ReadLine();

                        Console.WriteLine("Enter Price:");
                        decimal newPrice = decimal.Parse(Console.ReadLine());

                        lib.UpdateBook(id, newTitle, newAuthor, newPrice);
                        break;

                    case 4:
                        Console.WriteLine("Enter Book Id:");
                        int delId = int.Parse(Console.ReadLine());

                        lib.DeleteBook(delId);
                        break;

                    case 5:
                        Console.WriteLine("Enter Book Name:");
                        string name = Console.ReadLine();

                        lib.SearchBook(name);
                        break;

                    case 6:
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
