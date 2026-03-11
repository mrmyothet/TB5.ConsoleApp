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
        string? connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

        public async Task<bool> CanConnectSQLServerAsync()
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                Console.WriteLine("Missing CONNECTION_STRING");
                return false;
            }

            using var connection = new SqlConnection(connectionString);
            try
            {
                await connection.OpenAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Create()
        {
            string query = @"
                INSERT INTO [dbo].[Tbl_Product]
                       ([ProductCode]
                       ,[ProductName]
                       ,[Price])
                 VALUES
                       (@ProductCode
                       ,@ProductName
                       ,@Price)";

            SqlConnection connection = new SqlConnection();
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ProductCode", "P001");
            cmd.Parameters.AddWithValue("@ProductName", "Strawberry");
            cmd.Parameters.AddWithValue("@Price", 500);

            int result = cmd.ExecuteNonQuery();





        }

        public void Read()
        {

        }

        public void Edit()
        {

        }

        public void Update()
        {

        }

        public void Delete()
        {
        }   
    }

    public class Tbl_Product
    {
        public int Id { get; set; }

        public string ProductCode { get; set; }

        public string ProductName { get; set; }

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
