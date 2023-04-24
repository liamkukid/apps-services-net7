using Microsoft.Data.SqlClient;
using Packt.Shared;
using System.Data;
using BenchmarkDotNet;

var products = new List<Product>();
using (var context = new NorthwindContext())
{
    products = context.Products.ToList();
}

SqlConnectionStringBuilder builder = new();
builder.InitialCatalog = "Northwind";
builder.MultipleActiveResultSets = true;
builder.Encrypt = true;
builder.TrustServerCertificate = true;
builder.ConnectTimeout = 10;
builder.DataSource = ".";
builder.IntegratedSecurity = true;

SqlConnection connection = new(builder.ConnectionString);
connection.Open();

SqlCommand cmd = connection.CreateCommand();
cmd.CommandType = CommandType.Text;
cmd.CommandText = "SELECT * FROM Products";
SqlDataReader r = cmd.ExecuteReader();
List<object[]> objects = new List<object[]>();
while (r.Read())
{
    var row = new object[10];
    r.GetValues(row);
    objects.Add(row);
}

Console.ReadLine();