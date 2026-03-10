//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//Console.WriteLine("Waht is you name? ");
//string name = Console.ReadLine();

//Console.WriteLine($"Hello," + name);

using Microsoft.Data.SqlClient;

SqlConnection connection = new SqlConnection("Data Source=MYOTHETPC\\MSSQLEXPRESS2022;Initial Catelog=Batch5MiniPOS;User ID=sa;Password=admin123!;TrustedServerCertificate=True");
connection.Open();  

Console.ReadLine();

