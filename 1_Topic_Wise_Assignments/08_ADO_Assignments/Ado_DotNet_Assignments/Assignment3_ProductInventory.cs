using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Ado_Assignment.Assignment3
{
    class Assignment3_ProductInventory
    {
        private SqlConnection connection = null;
        private SqlDataAdapter adapter = null;
        private DataSet ds = null;
        private DataTable table = null;

        // YOUR CONNECTION STRING (UNCHANGED)
        string connectionString = "Data Source=DESKTOP-VDQELDT\\SQLEXPRESS;Initial Catalog=AdoDB;Integrated Security=True;Trust Server Certificate=True";

        public void LoadData()
        {
            try
            {
                connection = new SqlConnection(connectionString);
                adapter = new SqlDataAdapter("SELECT * FROM Products", connection);

                ds = new DataSet();
                adapter.Fill(ds, "Products");

                table = ds.Tables["Products"];

                Console.WriteLine("Data Loaded Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while loading data: " + ex.Message);
            }
        }

        public void DisplayProducts()
        {
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    if (row.RowState != DataRowState.Deleted)
                    {
                        Console.WriteLine("Id:{0} Name:{1} Price:{2} Stock:{3}",
                            row["ProductId"], row["ProductName"], row["Price"], row["Stock"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while displaying: " + ex.Message);
            }
        }

        public void AddProduct(string name, decimal price, int stock)
        {
            try
            {
                DataRow newRow = table.NewRow();
                newRow["ProductName"] = name;
                newRow["Price"] = price;
                newRow["Stock"] = stock;

                table.Rows.Add(newRow);

                Console.WriteLine("Product Added (Offline)");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while adding: " + ex.Message);
            }
        }

        public void UpdateProduct(int id, decimal price)
        {
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    if (row.RowState != DataRowState.Deleted && (int)row["ProductId"] == id)
                    {
                        row["Price"] = price;
                        Console.WriteLine("Product Updated (Offline)");
                        return;
                    }
                }

                Console.WriteLine("Product Not Found");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while updating: " + ex.Message);
            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    if (row.RowState != DataRowState.Deleted && (int)row["ProductId"] == id)
                    {
                        row.Delete();
                        Console.WriteLine("Product Deleted (Offline)");
                        return;
                    }
                }

                Console.WriteLine("Product Not Found");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while deleting: " + ex.Message);
            }
        }

        public void SaveChanges()
        {
            try
            {
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.Update(ds, "Products");

                Console.WriteLine("Changes Saved to Database");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while saving: " + ex.Message);
            }
        }
    }

    class Test_Assignment3_ProductInventory
    {
        static void Main()
        {
            Assignment3_ProductInventory obj = new Assignment3_ProductInventory();

            obj.LoadData();

            while (true)
            {
                Console.WriteLine("\n1.View 2.Add 3.Update 4.Delete 5.Save 6.Exit");
                int ch = int.Parse(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        obj.DisplayProducts();
                        break;

                    case 2:
                        Console.WriteLine("Enter Name:");
                        string name = Console.ReadLine();

                        Console.WriteLine("Enter Price:");
                        decimal price = decimal.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Stock:");
                        int stock = int.Parse(Console.ReadLine());

                        obj.AddProduct(name, price, stock);
                        break;

                    case 3:
                        Console.WriteLine("Enter Product Id:");
                        int id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter New Price:");
                        decimal newPrice = decimal.Parse(Console.ReadLine());

                        obj.UpdateProduct(id, newPrice);
                        break;

                    case 4:
                        Console.WriteLine("Enter Product Id:");
                        int delId = int.Parse(Console.ReadLine());

                        obj.DeleteProduct(delId);
                        break;

                    case 5:
                        obj.SaveChanges();
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