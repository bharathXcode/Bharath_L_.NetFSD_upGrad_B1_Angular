using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Ado_Assignment.Assignment4
{
    class Assignment4_OrderManagement
    {
        private SqlConnection connection = null;
        private SqlCommand command = null;

        string connectionString = "Data Source=DESKTOP-VDQELDT\\SQLEXPRESS;Initial Catalog=AdoDB;Integrated Security=True;Trust Server Certificate=True";

        public void PlaceOrder()
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // Insert into Orders
                        Console.WriteLine("Enter Customer Name:");
                        string customer = Console.ReadLine();

                        Console.WriteLine("Enter Total Amount:");
                        decimal amount = decimal.Parse(Console.ReadLine());

                        command = new SqlCommand(
                            "INSERT INTO Orders (CustomerName, TotalAmount) OUTPUT INSERTED.OrderId VALUES (@name, @amt)",
                            connection, transaction);

                        command.Parameters.AddWithValue("@name", customer);
                        command.Parameters.AddWithValue("@amt", amount);

                        int orderId = (int)command.ExecuteScalar();

                        Console.WriteLine("Order Created with ID: " + orderId);

                        // Insert multiple OrderItems
                        while (true)
                        {
                            Console.WriteLine("Enter Product Name (or type 'done' to finish):");
                            string pname = Console.ReadLine();

                            if (pname.ToLower() == "done")
                                break;

                            Console.WriteLine("Enter Quantity:");
                            int qty = int.Parse(Console.ReadLine());

                            SqlCommand itemCmd = new SqlCommand(
                                "INSERT INTO OrderItems (OrderId, ProductName, Quantity) VALUES (@oid, @pname, @qty)",
                                connection, transaction);

                            itemCmd.Parameters.AddWithValue("@oid", orderId);
                            itemCmd.Parameters.AddWithValue("@pname", pname);
                            itemCmd.Parameters.AddWithValue("@qty", qty);

                            itemCmd.ExecuteNonQuery();
                        }

                        // Commit transaction
                        transaction.Commit();
                        Console.WriteLine("Order and Items inserted successfully");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Transaction Failed: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection Error: " + ex.Message);
            }
        }
    }

    class Test_Assignment4_OrderManagement
    {
        static void Main()
        {
            Assignment4_OrderManagement obj = new Assignment4_OrderManagement();

            while (true)
            {
                Console.WriteLine("\n1. Place Order");
                Console.WriteLine("2. Exit");

                int ch = int.Parse(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        obj.PlaceOrder();
                        break;

                    case 2:
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
