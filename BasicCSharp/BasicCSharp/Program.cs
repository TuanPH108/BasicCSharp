using basic_csharp.SQLAdapter;
using Microsoft.Data.SqlClient;
using System.Data;

var sqlconnectstring = @"Data Source=tcp:10.88.54.131;Initial Catalog=BasicCSharp;User ID=sa;Password=Tuan01082002;
TrustServerCertificate=True
";


UserSQLAdapter usSQL1 = new UserSQLAdapter(sqlconnectstring);

ProductSQLAdapter proSQL1 = new ProductSQLAdapter(sqlconnectstring);


/*
SqlConnection connection = new SqlConnection(sqlconnectstring);
connection.Open();


SqlDataAdapter adapter = new SqlDataAdapter();

adapter.TableMappings.Add("Table", "Users");

adapter.SelectCommand = new SqlCommand(@"Select * From Users", connection);
DataTable UserTable = new DataTable();

adapter.Fill(UserTable);

foreach(DataRow row in UserTable.Rows)
{
    Console.WriteLine(row["User_ID"] + ", " + row["User_Name"] + ", "
        + row["User_Birthday"] + ", " + row["User_Email"] + ", " + row["User_Contact"]);
}
*/


