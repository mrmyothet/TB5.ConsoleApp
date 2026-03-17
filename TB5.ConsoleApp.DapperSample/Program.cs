using TB5.ConsoleApp.DapperSample.DapperSample;

var service = new DapperService();

//service.Create("Product 1", 100);
Console.WriteLine("Displaying Products...");
service.Read();

int productId = 1005;
service.Edit(productId);
Console.WriteLine();

string productName = "Updated Product Name";
decimal productPrice = 5000.55m;

service.Update(productId, productName, productPrice);
Console.WriteLine();

Console.WriteLine("Displaying Products...");
service.Read();

service.Delete(productId);
Console.WriteLine();

Console.WriteLine("Displaying Products...");
service.Read();

Console.ReadLine();
