using Microsoft.Data.SqlClient;
using TB5.ConsoleApp.AdoDotNetSample;


var service = new AdoDotNetService();
var result = await service.CanConnectSQLServerAsync();
Console.WriteLine(result ? "SQL Server connection successful." : "SQL Server connection failed.");

//var example = new Student();
//example.RunStudentClassExample();

Console.ReadLine();

