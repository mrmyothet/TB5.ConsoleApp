using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TB5.ConsoleApp.AdoDotNetSample
{
    public class AdoDotNetService
    {

        // fields
        // SELECT @@SERVERNAME
        // SELECT DB_NAME();

        //string? connectionString = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTION_STRING");
        private string connectionString = Environment.GetEnvironmentVariable("LOCAL_SQL_CONNECTION_STRING")!;

        public async Task<bool> CanConnectSQLServerAsync()
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                Console.WriteLine("Missing CONNECTION_STRING");
                return false;
            }
            //Console.WriteLine(connectionString);

            using var connection = new SqlConnection(connectionString);
            try
            {
                await connection.OpenAsync();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Failed to connect to SQL Server.");
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void Create(string productName, decimal productPrice)
        {
            string query = @"
                INSERT INTO [dbo].[Tbl_Product]
                       ([Name]
                       ,[Price])
                 VALUES
                       (@Name
                       ,@Price)";

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Name", productName);
            cmd.Parameters.AddWithValue("@Price", productPrice);

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            string mesage = result > 0 ? "Product creation successful." : "Product creation failed.";
            Console.WriteLine(mesage);

        }

        public void Read()
        {

        }

        public void Edit()
        {

        }

        public void Update(int productId, string productName, decimal productPrice)
        {
            string query = @"
                UPDATE [dbo].[Tbl_Product]
                SET [Name] = @Name
                    ,[Price] = @Price
                WHERE Id = @Id";

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", productId);
            cmd.Parameters.AddWithValue("@Name", productName);
            cmd.Parameters.AddWithValue("@Price", productPrice);

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            string mesage = result > 0 ? "Product Update successful." : "Product Update failed.";
            Console.WriteLine(mesage);
        }

        public void Delete(int productId)
        {
            string query = @"
                DELETE 
                FROM [dbo].[Tbl_Product]
                WHERE Id=@Id";

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", productId);

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            string mesage = result > 0 ? $"Delete Product Id {productId} successful." : $"Delete Product Id {productId} failed.";
            Console.WriteLine(mesage);
        }   
    }

    public class Tbl_Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }

    public class Tbl_Sale
    {
        public int SaleId { get; set; }

        public int ProductId { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public DateTime? SaleDate { get; set; }
    }
}
