using basic_csharp.SQLAdapter;
using BasicCSharp.Object;
using Microsoft.Data.SqlClient;
using System.Data;

//Connection through TCP/IP
string SQL_Connection = @"Data Source=tcp:192.168.1.9;Initial Catalog=BasicCSharp;User ID=sa;Password=Tuan01082002;
TrustServerCertificate=True
";


UserSQLAdapter User_Adapter = new UserSQLAdapter(SQL_Connection);

//Test Get Data base on ID
Users user1 = User_Adapter.Get(Guid.Parse("b99590f5-76ac-4a15-9988-8abf37304746"));

Console.WriteLine("#__USERS__#Select * From Users Where Users.User_ID = .... by Get(ID) Method##\n");
Console.WriteLine($"{user1.User_ID}, {user1.User_Name}, {user1.User_Birthday}, {user1.User_Email}, {user1.User_Contact}");

//Test  with Already Object
Users insertUser = new Users(Guid.NewGuid(), "Tuan PH 108 ", "2000-08-08", "TuanPH108@gmail.com", "0857766738");
Console.WriteLine("\n#__USER__##Insert into Users ==> " + User_Adapter.Insert(insertUser) + " row was added");



//Test Update
Console.WriteLine("\n#__USER__##UPDATE Users ==> " + User_Adapter.Update(insertUser) + " row was updated");



//Test Get All Data Table
Console.WriteLine("\n#__USERS__#Select * From Users by GetData() Method##\n");
foreach (Users user in User_Adapter.GetData())
{
    Console.WriteLine($"{user.User_ID}, {user.User_Name}, {user.User_Birthday}, {user.User_Email}, {user.User_Contact} \n");
}